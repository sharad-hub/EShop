using System;
namespace Shop.Services
{
  public  interface IEncryptionService
    {
        string CreateSalt();
        string EncryptPassword(string password, string salt);
    }
}
