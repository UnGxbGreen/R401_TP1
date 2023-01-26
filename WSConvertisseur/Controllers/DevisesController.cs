using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        public List<Devise> listDevises = new List<Devise>();

        public DevisesController()
        {
            listDevises.Add(new Devise(1, "Dollar", 1.08));
            listDevises.Add(new Devise(2, "Franc Suisse", 1.07));
            listDevises.Add(new Devise(3, "Yen", 120));



        }




        /// <summary>
        /// Get all currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        /// <response code="400">When the currency id is not found</response>
        // GET: api/<DevisesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return listDevises;
        }

        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        /// <response code="400">When the currency id is not found</response>
        // GET api/<DevisesController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        public ActionResult<Devise> GetById(int id)
        {
            Devise? devise =
            (from d in listDevises
             where d.IdDevise == id
             select d).FirstOrDefault();
            if (devise == null)
            {
                return NotFound();
            }
            return devise;
        }


        /// <summary>
        /// Add a currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="devise">The currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        /// <response code="400">When the currency id is not found</response>
        // POST api/<DevisesController>
        [HttpPost]
        public ActionResult<Devise> Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            listDevises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.IdDevise }, devise);
        }
        /// <summary>
        /// Update a currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <param name="devise">The currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        /// <response code="400">When the currency id is not found</response>
        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.IdDevise)
            {
                return BadRequest();
            }
            int index = listDevises.FindIndex((d) => d.IdDevise == id);
            if (index < 0)
            {
                return NotFound();
            }
            listDevises[index] = devise;
            return NoContent();
        }

        /// <summary>
        /// delete a currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        /// <response code="400">When the currency id is not found</response>
        // DELETE api/<DevisesController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        public ActionResult<Devise> Delete(int id)
        {
            Devise? devise =
           (from d in listDevises
            where d.IdDevise == id
            select d).FirstOrDefault();
            if (devise == null)
            {
                return NotFound();
            }
            listDevises.Remove(devise);
            return NoContent();
        }
    }
}
