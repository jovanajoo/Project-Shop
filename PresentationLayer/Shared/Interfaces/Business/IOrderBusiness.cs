using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.Business
{
    public interface IOrderBusiness
    {
        List<Order> GetAllOrders();
        bool InsertOrders(Order o);
        int GetNowOrder();
        bool DeleteOrdersById(int OrderID);
        bool UpdateOrder(Order o);
    }
}
