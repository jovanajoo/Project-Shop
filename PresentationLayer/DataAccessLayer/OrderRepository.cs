using Shared.Models;
using Shared.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetAllOrders()
        {
            List<Order> results = new List<Order>();
            SqlDataReader sqlDataReader = DBConnection.GetData("SELECT * FROM Orders");
            while (sqlDataReader.Read())
            {
                Order o = new Order();
                o.OrderID = sqlDataReader.GetInt32(0);
                o.CustomerID = sqlDataReader.GetInt32(1);
                o.OrderDate = sqlDataReader.GetDateTime(2);
                o.DeliveryDate = sqlDataReader.GetDateTime(3);

                results.Add(o);

            }
            DBConnection.CloseConnection();
            return results;
        }
    }
}
