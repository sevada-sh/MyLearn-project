using MyLearn.Application.Interfaces;
using MyLearn.Domain.Interfaces;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;




namespace MyLearn.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddFactorDetail(FactorDetail factordetail)
        {
            _orderRepository.AddOrderDetails(factordetail);
        }

        public void AddOrder(Factor order)
        {
            _orderRepository.AddOrder(order);
        }

        public FactorDetail Find(int detailId)
        {
            return _orderRepository.Find(detailId);
        }

        public Factor FindFactor(int factorId)
        {
            return _orderRepository.FindFactor(factorId);
        }

        public int FindFirst()
        {
            return 0;
            //return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
        }

        public FactorDetail FirstOrDefaultFactorDetails(int courseId, int factorId)
        {
            return _orderRepository.FirstOrDefaultFactorDetails(courseId, factorId);
        }

        public Factor FirstOrDefaultOrder(int userId)
        {
            return _orderRepository.FirstOrDefaultOrder(userId);
        }

        public void Remove(FactorDetail factordetail)
        {
            _orderRepository.Remove(factordetail);
        }

        public void Save()
        {
            _orderRepository.Save();
        }

        public Factor ShowCart(int userId)
        {
            return _orderRepository.ShowCart(userId);
        }

        public Factor SingleOrDefaultOrder()
        {
            return _orderRepository.SingleOrDefaultOrder();
        }

        public void Update(Factor order)
        {
            _orderRepository.Update(order);
        }
    }
}
