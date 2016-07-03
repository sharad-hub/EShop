using Shop.Entities;
using Shop.Services.Utilities;
using System;
namespace Shop.Services
{
   public interface IMembershipService
    {
         User CreateUser(string username, string email, string password, int[] roles);
         User GetUser(int userId);
        System.Collections.Generic.List<Role> GetUserRoles(string username);
        MembershipContext ValidateUser(string username, string password);
    }
}
