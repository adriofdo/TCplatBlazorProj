using System;

namespace SQLDatAccessLibrary.Anagrafici
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataDiNascita { get; set; }
        public string Scuola { get; set; }
        public string Indirizzo { get; set; }
        public string CodiceFiscale { get; set; }
        public string PaeseDiNascita { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // This should store the encrypted password
     public bool ActState { get; set; } 
        public string Role {  get; set; }

    }
}
