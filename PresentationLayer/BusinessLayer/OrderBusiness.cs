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

        public bool InsertOrders(Order o)
        {
            if(this.orderRepository.InsertOrders(o) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int GetNowOrder()
        {
            return this.orderRepository.GetNewOrder();
        }

        public bool DeleteOrdersById(int OrderID)
        {
            if (this.orderRepository.DeleteOrdersById(OrderID) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateOrder(Order o)
        {
            if (this.orderRepository.UpdateOrder(o) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
