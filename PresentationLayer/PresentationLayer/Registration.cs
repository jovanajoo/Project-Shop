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
    public partial class Registration : Form
    {
        private readonly ICustomerBusiness customerBusiness;
        public Registration(ICustomerBusiness _customerBusiness)
        {
            this.customerBusiness = _customerBusiness;
            InitializeComponent();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if (CheckTextBox())
            {
                Customer c = new Customer()
                {
                    UserName = textBoxUsername.Text,
                    Name = textBoxName.Text,
                    Email = textBoxEmail.Text,
                    City = textBoxCity.Text,
                    Address = textBoxAddress.Text,
                    PhoneNumber = textBoxNumber.Text,
                    Password = textBoxPassword.Text

                };
                if (this.customerBusiness.InsertCustomer(c))
                {
                    MessageBox.Show("Successful registration!");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
            
        }


        private bool CheckTextBox()
        {
            TextBox tb = this.Controls.OfType<TextBox>().FirstOrDefault(c => c.Text.Length == 0);
            if(tb != null)
            {
                tb.Focus();
                MessageBox.Show("You need to fill inputs");
                return false;
            }
            return true;
        }
    }
}
