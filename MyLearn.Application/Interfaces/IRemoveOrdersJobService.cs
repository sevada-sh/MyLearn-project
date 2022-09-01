using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.Interfaces
{
    public interface IRemoveOrdersJobService
    {
        void Save();

        void RemoveFactor(Factor order);

        void RemoveFactorDetail(FactorDetail detail);

        IEnumerable<Factor> WhereOrders();

        IEnumerable<FactorDetail> WhereOrderDetails(int orderId);
    }
}
