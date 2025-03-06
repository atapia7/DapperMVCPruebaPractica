using System.Data;

namespace DapperMVC.Data.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters);
        Task SaveData<T>(string spName, T parameters);
        IDbConnection GetConnection();
    }
}