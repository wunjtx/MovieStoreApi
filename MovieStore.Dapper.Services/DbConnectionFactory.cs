using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MovieStore.Dapper.Services
{
    public class DbConnectionFactory:IDbConntectionFactory
    {
        private IDbConnection _connection;
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_configuration.GetConnectionString("MovieStoreConnection"));
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
