using MovieStore.Dapper.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Dapper.Services.Implementation
{
    public class CryptoService : ICryptoService
    {
        private readonly IDbConntectionFactory _dbConntectionFactory;
        public CryptoService(IDbConntectionFactory dbConntectionFactory)
        {
            _dbConntectionFactory = dbConntectionFactory;
        }
        public string CreateSalt()
        {
            throw new NotImplementedException();
        }

        public string HashPassword(string password, string salt)
        {
            throw new NotImplementedException();
        }
    }
}
