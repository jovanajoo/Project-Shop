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
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            List<Category> results = new List<Category>();
            SqlDataReader sqlDataReader = DBConnection.GetData("SELECT * FROM Categories");

            while (sqlDataReader.Read())
            {
                Category c = new Category();
                c.CategoryID = sqlDataReader.GetInt32(0);
                c.Name = sqlDataReader.GetString(1);
                c.Description = sqlDataReader.GetString(2);

                results.Add(c);
            }

            return results;
        }
    }
}
