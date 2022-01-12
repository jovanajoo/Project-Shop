using Shared.Interfaces.Business;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Login : Form
    {
        private readonly ICustomerBusiness customerBusiness;
        public Login(ICustomerBusiness _customerBusiness)
        {
            this.customerBusiness = _customerBusiness;
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textBoxUserName.Text.Length != 0 && textBoxPassword.Text.Length != 0)
            {

                Customer c = customerBusiness.GetCustomerByUserAndPass(textBoxUserName.Text, textBoxPassword.Text);
                if(c != null)
                {
                    MainForm.currentCustomer = c;
                    MessageBox.Show("You have successfully logged in!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!");
                }
            }
            else
            {
                MessageBox.Show("Please enter your username and password!");
            }
        }
    }
}
