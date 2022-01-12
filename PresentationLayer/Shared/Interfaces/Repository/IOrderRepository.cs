using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        int InsertOrders(Order o);
        int GetNewOrder();
        int DeleteOrdersById(int OrderID);
        int UpdateOrder(Order o);


    }
}
