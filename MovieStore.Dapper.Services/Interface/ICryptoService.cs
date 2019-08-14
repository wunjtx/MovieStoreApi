using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Dapper.Services.Interface
{
    public interface ICryptoService
    {
        string CreateSalt();
        string HashPassword(string password, string salt);
    }
}
