using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Factor FirstOrDefaultOrder(int userId);

        void AddOrder(Factor order);

        Factor SingleOrDefaultOrder();

        void Save();

        void AddOrderDetails(FactorDetail factordetail);

        FactorDetail FirstOrDefaultFactorDetails(int courseId, int factorId);

        Factor ShowCart(int userId);

        FactorDetail Find(int detailId);

        void Remove(FactorDetail factordetail);

        Factor FindFactor(int factorId);

        void Update(Factor order);
    }
}
