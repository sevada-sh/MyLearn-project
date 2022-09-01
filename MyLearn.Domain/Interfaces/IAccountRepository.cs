using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Interfaces
{
    public interface IAccountRepository
    {
        bool IsExistUser(string email, string password);
        void AddUser(Account user);
        void Save();
        bool IsExistEmail(string email);
        bool IsExistUserName(string username);
        Account GetAnAccount(Account account);

        IEnumerable<Account> GetAllAccounts();

        Account FindAccount(int accountId);

        IEnumerable<Account> FindAccounts(int accountId);

        void AddAccount(Account account);

        void DeleteAccount(Account account);

    }
}
