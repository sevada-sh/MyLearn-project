using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.Interfaces
{
    public interface IAccountService
    {
        bool IsExistUser(string email, string password);

        int RegisterUser(Account user);

        bool IsExistUserName(string username);
        bool IsExistEmail(string email);
        Account GetAnAccount(Account account);

        IEnumerable<Account> GetAllAccounts();

        Account FindAccount(int accountId);

        IEnumerable<Account> FindAccounts(int accountId);

        void Save();

        void AddAccount(Account account);

        void DeleteAccount(Account account);

    }
}
