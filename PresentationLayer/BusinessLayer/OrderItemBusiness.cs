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
    public class OrderItemBusiness : IOrderItemBusiness
    {
        private readonly IOrderItemRepository orderItemRepository;


        public OrderItemBusiness(IOrderItemRepository _orderItemRepository)
        {
            this.orderItemRepository = _orderItemRepository;
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return this.orderItemRepository.GetAllOrderItems();
        }

        public bool InsertOrderItems(OrderItem oi)
        {
            if (this.orderItemRepository.InsertOrderItems(oi) > 0)
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
