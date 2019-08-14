using System.Data;

namespace MovieStore.Dapper.Services
{
    public interface IDbConntectionFactory
    {
        IDbConnection GetConnection { get; }

        void CloseConnection();
    }
}