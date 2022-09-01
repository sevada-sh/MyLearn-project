using MyLearn.Application.Interfaces;
using MyLearn.Application.Security;
using MyLearn.Application.ViewModels;
using MyLearn.Domain.Interfaces;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountrepository;
        public AccountService(IAccountRepository accountrepository)
        {
            _accountrepository = accountrepository;
        }

        public void AddAccount(Account account)
        {
            _accountrepository.AddAccount(account);
        }

        public void DeleteAccount(Account account)
        {
            _accountrepository.DeleteAccount(account);
        }

        public Account FindAccount(int accountId)
        {
            return _accountrepository.FindAccount(accountId);
        }

        public IEnumerable<Account> FindAccounts(int accountId)
        {
            return _accountrepository.FindAccounts(accountId);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _accountrepository.GetAllAccounts().ToList();
        }

        public Account GetAnAccount(Account account)
        {

            return _accountrepository.GetAnAccount(account);
        }

        public bool IsExistEmail(string email)
        {
            return _accountrepository.IsExistEmail(email);
        }

        public bool IsExistUser(string email, string password)
        {
            return _accountrepository.IsExistUser(email.Trim().ToLower(), PasswordHelper.EncodePasswordMd5(password));
        }

        public bool IsExistUserName(string username)
        {
            return _accountrepository.IsExistUserName(username);
        }

        public int RegisterUser(Account user)
        {
            _accountrepository.AddUser(user);
            return user.UserId;

        }

        public void Save()
        {
            _accountrepository.Save();
        }
    }
}
