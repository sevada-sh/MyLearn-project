using MyLearn.Data.Context;
using MyLearn.Domain.Interfaces;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private MyLearnContext _context;
        public AccountRepository(MyLearnContext context)
        {
            _context = context;
        }

        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
        }

        public void AddUser(Account user)
        {
            _context.Accounts.Add(user);
        }

        public void DeleteAccount(Account account)
        {
            _context.Accounts.Remove(account);
        }

        public Account FindAccount(int accountId)
        {
            return _context.Accounts.Find(accountId);
        }

        public IEnumerable<Account> FindAccounts(int accountId)
        {
            return (IEnumerable<Account>)_context.Accounts.Find(accountId);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _context.Accounts;
        }

        public Account GetAnAccount(Account account)
        {
            return _context.Accounts.SingleOrDefault(a => a.Equals(account));
        }

        public bool IsExistEmail(string email)
        {
            return _context.Accounts.Any(e => e.Email == email);
        }

        public bool IsExistUser(string email, string password)
        {
            return _context.Accounts.Any(e => e.Email == email && e.Password == password);
        }

        public bool IsExistUserName(string username)
        {
            return _context.Accounts.Any(u => u.UserName == username);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
