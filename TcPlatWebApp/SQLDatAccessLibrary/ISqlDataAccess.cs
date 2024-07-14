
namespace SQLDatAccessLibrary
{
    public interface ISqlDataAccess
    {
        string ConnectionString { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
    }
}