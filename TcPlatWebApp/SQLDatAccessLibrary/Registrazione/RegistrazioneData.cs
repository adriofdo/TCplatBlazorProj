using System.Threading.Tasks;

namespace SQLDatAccessLibrary.Anagrafici
{
    public class RegistrazioneData : IRegistrazioneData
    {
        private readonly ISqlDataAccess _db;

        public RegistrazioneData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task InsertRegistrazione(RegistrationModel model)
        {
            // Encrypt the password before saving
            string encryptedPassword = EncryptPassword(model.Pwd);

            string sql = @"
                INSERT INTO dbo.tblInfoAnagrafici 
                (Nome, Cognome, DataDiNascita, Scuola, Indirizzo, CodiceFiscale, PaeseDiNascita, Username, Pwd, ActState)
                VALUES (@Nome, @Cognome, @DataDiNascita, @Scuola, @Indirizzo, @CodiceFiscale, @PaeseDiNascita, @Username, @Pwd, '0');";

            // Creating a parameter object that includes the encrypted password
            var parameters = new
            {
                model.Nome,
                model.Cognome,
                model.DataDiNascita,
                model.Scuola,
                model.Indirizzo,
                model.CodiceFiscale,
                model.PaeseDiNascita,
                model.Username,
                Pwd = encryptedPassword, // Use the encrypted password here
                CreatedAt = DateTime.UtcNow
            };

            await _db.SaveData(sql, parameters);
        }

        private string EncryptPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
