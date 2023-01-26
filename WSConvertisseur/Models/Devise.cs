using System.ComponentModel.DataAnnotations;

namespace WSConvertisseur.Models
{
    public class Devise
    {

        private int idDevise;
        private string? nomDevise;
        private double tauxDevise;


        public Devise()
        {

        }

        public Devise(int idDevise, string? nomDevise, double tauxDevise)
        {
            this.IdDevise = idDevise;
            this.NomDevise = nomDevise;
            this.TauxDevise = tauxDevise;
        }

        public int IdDevise
        {
            get
            {
                return idDevise;
            }

            set
            {
                idDevise = value;
            }
        }

        [Required]
        public string? NomDevise
        {
            get
            {
                return nomDevise;
            }

            set
            {
                nomDevise = value;
            }
        }

        public double TauxDevise
        {
            get
            {
                return tauxDevise;
            }

            set
            {
                tauxDevise = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Devise devise &&
                   this.IdDevise == devise.IdDevise &&
                   this.NomDevise == devise.NomDevise &&
                   this.TauxDevise == devise.TauxDevise;
        }
    }
}
