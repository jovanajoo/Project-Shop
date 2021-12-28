using Shared.Interfaces.Business;
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
    public partial class MainForm : Form
    {
        private readonly IProductBusiness productBusiness;
        private readonly ICustomerBusiness customerBusiness;

        public MainForm(IProductBusiness _productBusiness, ICustomerBusiness _customerBusiness)
        {
            this.productBusiness = _productBusiness;
            this.customerBusiness = _customerBusiness;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdministration_Click(object sender, EventArgs e)
        {
            Administration a = new Administration(this.productBusiness);
            a.ShowDialog();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login lg = new Login(this.customerBusiness);
            lg.ShowDialog();
        }

        private void buttonToReg_Click(object sender, EventArgs e)
        {
            Registration rg = new Registration(this.customerBusiness);
            rg.ShowDialog();
        }

    }
}
