
namespace SQLDatAccessLibrary.Anagrafici
{
    public interface IRegistrazioneData
    {
        Task InsertRegistrazione(RegistrationModel model);
    }
}