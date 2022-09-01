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
    public class RemoveOrdersJobRepository: IRemoveOrdersJobRepository
    {
        private readonly MyLearnContext _context;
        public RemoveOrdersJobRepository(MyLearnContext context)
        {
            _context = context;
        }

        public void RemoveFactor(Factor order)
        {
            _context.Remove(order);
        }

        public void RemoveFactorDetail(FactorDetail detail)
        {
            _context.Remove(detail);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<FactorDetail> WhereOrderDetails(int orderId)
        {
            return (IEnumerable<FactorDetail>)_context.FactorDetails.Where(o => o.FactorId == orderId);
        }

        public IEnumerable<Factor> WhereOrders()
        {
            return (IEnumerable<Factor>)_context.Factors.Where(o => !o.IsFinally && o.CreateDate < DateTime.Now.AddHours(-24));
        }
    }
}
