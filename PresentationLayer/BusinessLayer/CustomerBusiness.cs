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
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerBusiness(ICustomerRepository _customerRepository)
        {
            this.customerRepository = _customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return this.customerRepository.GetAllCustomers();
        }

        public bool InsertCustomer(Customer c)
        {
            if (this.customerRepository.InsertCustomers(c) > 0)
                return true;
            else
                return false;
        }

        public bool DeleteCustomerById(int Id)
        {
            if(this.customerRepository.DeleteCustomerById(Id) > 0)
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
