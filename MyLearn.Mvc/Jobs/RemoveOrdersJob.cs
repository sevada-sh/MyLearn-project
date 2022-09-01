using Microsoft.EntityFrameworkCore;
using MyLearn.Application.Interfaces;
using MyLearn.Data.Context;
using Quartz;

namespace MyLearn.Mvc.Jobs
{
    [DisallowConcurrentExecution]
    public class RemoveOrdersJob : IJob
    {
        private readonly IRemoveOrdersJobService _removeordersjobservice;
        public RemoveOrdersJob(IRemoveOrdersJobService removeordersjobservice)
        {
            _removeordersjobservice = removeordersjobservice;
        }
        public Task Execute(IJobExecutionContext context)
        {
            //var option = new DbContextOptionsBuilder<MyLearnContext>();
            //option.UseSqlServer("name=ConnectionStrings:MyLearnCon");
            //using ()
            //{
            var orders = _removeordersjobservice.WhereOrders();
            foreach (var order in orders)
            {
                var orderdetails = _removeordersjobservice.WhereOrderDetails(order.OrderId);
                foreach (var detail in orderdetails)
                {
                    _removeordersjobservice.RemoveFactorDetail(detail);
                }
                _removeordersjobservice.RemoveFactor(order);
            }
            _removeordersjobservice.Save();
            //}

            return Task.CompletedTask;
        }
    }
}
