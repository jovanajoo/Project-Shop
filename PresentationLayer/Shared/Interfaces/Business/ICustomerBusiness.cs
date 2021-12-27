using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.Business
{
    public interface ICustomerBusiness
    {
        List<Customer> GetAllCustomers();
        bool InsertCustomer(Customer c);
        bool DeleteCustomerById(int Id);
        Customer GetCustomerByUserAndPass(string User, string Pass);
    }
}
