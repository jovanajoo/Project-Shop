using Shared.Interfaces.Business;
using Shared.Interfaces.Repository;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IOrderRepository orderRepository;

        public OrderBusiness(IOrderRepository _orderRepository)
        {
            this.orderRepository = _orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return this.orderRepository.GetAllOrders();
        }
    }
}
