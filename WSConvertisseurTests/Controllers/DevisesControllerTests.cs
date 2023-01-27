using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSConvertisseur.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;
using Microsoft.AspNetCore.Http;

namespace WSConvertisseur.Controllers.Tests
{
    
    [TestClass()]

    public class DevisesControllerTests
    {
        public DevisesController controller;
        [TestInitialize]
        public void InitialisationDesTests()
        { 
            controller= new DevisesController();
            
        
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            //DevisesController controller = new DevisesController();
            // Act
            var result = controller.GetById(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsNull(result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result.Value, typeof(Devise), "Pas une Devise"); // Test du type du contenu (valeur) du retour
            Assert.AreEqual(new Devise(1, "Dollar", 1.08), (Devise?)result.Value, "Devises pas identiques"); //Test de la devise récupérée
        }

        [TestMethod]
        public void GetById_UnknownGuiPassed_ReturnsNotFoundResult()
        {
            // Arrange
           // DevisesController controller = new DevisesController();
            // Act
            var result = controller.GetById(4);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsNull(result.Value, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "Pas une Devise"); // Test du type du contenu (valeur) du retour
            //Assert.AreEqual(new Devise(5, "test", 5), (Devise?)result.Value, "Devises pas identiques"); //Test de la devise récupérée
        }

        [TestMethod]
        public void GetAll_GoodReturn()
        {

            // Arrange
           // DevisesController controller = new DevisesController();
            // Act

            var result = controller.GetAll();
            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Devise>), "Pas un IEnumerable"); // Test du type de retour
            CollectionAssert.AreEqual(result.ToList(), controller.listDevises, "Les listes ne sont pas les mêmes"); //Test de l'erreur
        }

        [TestMethod]
        public void Post_ValidObject()
        {

            // Arrange
           // DevisesController controller = new DevisesController();
            // Act

            var result = controller.Post(new Devise(4, "babaz", 15));
            // Assert


            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtRouteResult), "pas de type CreatedAtRouteResult"); //Test de l'erreur
            CreatedAtRouteResult routeResult = (CreatedAtRouteResult)result.Result;
            Assert.AreEqual(StatusCodes.Status201Created, routeResult.StatusCode, "pas un StatusCode");
            Assert.AreEqual(routeResult.Value, new Devise(4, "babaz", 15), "Pas la bonne valeur");
        }

        [TestMethod]
        public void Post_InvalidObject()
        {

            // Arrange
            //DevisesController controller = new DevisesController();
            // Act

            var result = controller.Post(new Devise(4, null, 15));
            // Assert


            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtRouteResult), "pas de type CreatedAtRouteResult"); //Test de l'erreur
            CreatedAtRouteResult routeResult = (CreatedAtRouteResult)result.Result;
            Assert.AreEqual(StatusCodes.Status201Created, routeResult.StatusCode, "pas un StatusCode");
            Assert.AreEqual(routeResult.Value, new Devise(4, null, 15), "Pas la bonne valeur");
        }
        [TestMethod]
        public void Put_InvalidUpdate_ReturnsBadRequest()
        {
            //Arrange
            //var controller = new DevisesController();
            // Act
            var result = controller.Put(1,new Devise(4,"Pakistan",10));

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult), "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result, typeof(BadRequestResult), "pas de type BadRequestResult"); //Test de l'erreur
            BadRequestResult badRequestResult = (BadRequestResult)result;
            Assert.AreEqual(StatusCodes.Status400BadRequest, badRequestResult.StatusCode, "pas un StatusCode");
        }

        [TestMethod]
        public void Put_InvalidUpdate_ReturnsNotFound()
        {
            //Arrange
            //var controller = new DevisesController();
            // Act
            var result = controller.Put(100, new Devise(100, "Pakistan", 10));

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult), "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "pas de type NotFoundResult"); //Test de l'erreur
            NotFoundResult notFoundtResult = (NotFoundResult)result;
            Assert.AreEqual(StatusCodes.Status404NotFound, notFoundtResult.StatusCode, "pas un StatusCode");
        }


        [TestMethod]
        public void Put_InvalidUpdate_ReturnsNoContent()
        {
            //Arrange
            //var controller = new DevisesController();
            // Act
            var result = controller.Put(1, new Devise(1, "Pakistan", 10));

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult), "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result, typeof(NoContentResult), "pas de type NoContentResult"); //Test de l'erreur
            NoContentResult noContentResult = (NoContentResult)result;
            Assert.AreEqual(StatusCodes.Status204NoContent, noContentResult.StatusCode, "pas un StatusCode");
        }

        [TestMethod]
        public void Delete_NotOk_ReturnsNotFound()
        {
            // Arrange
            //DevisesController controller = new DevisesController();
            // Act
            var result = controller.Delete(100);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            //Assert.IsInstanceOfType(result, typeof(NotFoundResult), "pas de type NoContentResult"); //Test de l'erreur
            NotFoundResult notFoundResult = (NotFoundResult)result.Result;
            Assert.AreEqual(StatusCodes.Status404NotFound, notFoundResult.StatusCode, "pas un StatusCode");
        }

        public void Delete_Ok_ReturnsRightItem()
        {
            // Arrange
           // DevisesController controller = new DevisesController();
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            //Assert.IsInstanceOfType(result, typeof(NotFoundResult), "pas de type NoContentResult"); //Test de l'erreur
            NotFoundResult notFoundResult = (NotFoundResult)result.Result;
            Assert.AreEqual(StatusCodes.Status404NotFound, notFoundResult.StatusCode, "pas un StatusCode");
        }



    }
}