using System;
using System.ComponentModel.DataAnnotations;

namespace SQLDatAccessLibrary.Anagrafici
{
    public class RegistrationModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cognome { get; set; }

        [Required]
        public DateTime DataDiNascita { get; set; }

        [Required]
        public string Scuola { get; set; }

        [Required]
        public string Indirizzo { get; set; }

        [Required]
        public string CodiceFiscale { get; set; }

        [Required]
        public string PaeseDiNascita { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "La password deve contenere almeno 6 caratteri.")]
        public string Pwd { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Le password non corrispondono.")]
        public string ConfirmPwd { get; set; }
    }
}
