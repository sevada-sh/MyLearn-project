using MyLearn.Data.Context;
using MyLearn.Domain.Interfaces;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyLearn.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyLearnContext _context;
        public OrderRepository(MyLearnContext context)
        {
            _context = context;
        }
        public void AddOrder(Factor order)
        {
            _context.Factors.Add(order);
        }

        public void AddOrderDetails(FactorDetail factordetail)
        {
            _context.FactorDetails.Add(factordetail);
        }

        public FactorDetail Find(int detailId)
        {
            return _context.FactorDetails.Find(detailId);
        }

        public Factor FindFactor(int factorId)
        {
            return _context.Factors.Find(factorId);
        }

        public FactorDetail FirstOrDefaultFactorDetails(int courseId, int factorId)
        {
            return _context.FactorDetails.FirstOrDefault(d => d.FactorId == factorId && d.CourseId == courseId);
        }

        public Factor FirstOrDefaultOrder(int userId)
        {
            return _context.Factors.FirstOrDefault(o => o.UserId == userId && !o.IsFinally);
        }

        public void Remove(FactorDetail factordetail)
        {
            _context.Remove(factordetail);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Factor ShowCart(int userId)
        {
            return _context.Factors.Where(o => o.UserId == userId && !o.IsFinally)
                .Include(o => o.factordetails)
                .ThenInclude(d => d.courses).FirstOrDefault();
        }

        public Factor SingleOrDefaultOrder()
        {
            return _context.Factors.SingleOrDefault(o => !o.IsFinally);
        }

        public void Update(Factor order)
        {
             _context.Factors.Update(order);
        }
    }
}
