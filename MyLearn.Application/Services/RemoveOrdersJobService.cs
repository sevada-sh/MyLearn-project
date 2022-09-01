using MyLearn.Application.Interfaces;
using MyLearn.Domain.Interfaces;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.Services
{
    public class RemoveOrdersJobService : IRemoveOrdersJobService
    {
        private readonly IRemoveOrdersJobRepository _removeordersjobrepositoy;
        public RemoveOrdersJobService(IRemoveOrdersJobRepository removeordersjobrepositoy)
        {
            _removeordersjobrepositoy = removeordersjobrepositoy;
        }

        public void RemoveFactor(Factor order)
        {
            _removeordersjobrepositoy.RemoveFactor(order);
        }

        public void RemoveFactorDetail(FactorDetail detail)
        {
            _removeordersjobrepositoy.RemoveFactorDetail(detail);
        }

        public void Save()
        {
            _removeordersjobrepositoy.Save();
        }

        public IEnumerable<FactorDetail> WhereOrderDetails(int orderId)
        {
            return _removeordersjobrepositoy.WhereOrderDetails(orderId).ToList();
        }

        public IEnumerable<Factor> WhereOrders()
        {
            return _removeordersjobrepositoy.WhereOrders().ToList();
        }
    }
}
