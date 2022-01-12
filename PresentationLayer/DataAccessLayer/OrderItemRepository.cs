using Shared.Interfaces.Repository;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public List<OrderItem> GetAllOrderItems()
        {
            List<OrderItem> results = new List<OrderItem>();
            SqlDataReader sqlDataReader = DBConnection.GetData("SELECT * FROM Order_Items");

            while (sqlDataReader.Read())
            {
                OrderItem oi = new OrderItem();
                oi.OrderItemID = sqlDataReader.GetInt32(0);
                oi.OrderID = sqlDataReader.GetInt32(1);
                oi.ProductID = sqlDataReader.GetInt32(2);
                oi.Quantity = sqlDataReader.GetInt32(3);


                results.Add(oi);
            }
            DBConnection.CloseConnection();
            return results;
        }

        public int InsertOrderItems(OrderItem oi)
        {
            var result = DBConnection.EditData(string.Format("INSERT INTO Order_Items VALUES({0},'{1}', '{2}')", oi.Quantity, oi.ProductID, oi.OrderID));
            DBConnection.CloseConnection();
            return result;

        }

    }
}
