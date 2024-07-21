
namespace SQLDatAccessLibrary.Anagrafici
{
    public interface IAnagraficiData
    {
        Task<List<AnagraficiModel>> GetAnagrafici();
    }
}