using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.RepositoryInterfaces
{
    public interface ICryptoService
    {
        string CreateSalt();
        string HashPassword(string password, string salt);
    }
}
