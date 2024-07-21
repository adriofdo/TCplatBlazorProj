using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDatAccessLibrary.Anagrafici
{
    public class AnagraficiModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataDiNascita { get; set; }
        public string Scuola { get; set; }
        public string Indirizzo { get; set; }
        public string CodiceFiscale { get; set; }
        public string PaeseDiNascita { get; set; }
    }
}
