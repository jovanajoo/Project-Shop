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
    public partial class MainForm : Form
    {
        private readonly IProductBusiness productBusiness;
        private readonly ICustomerBusiness customerBusiness;
        private readonly IOrderBusiness orderBusiness;
        private readonly IOrderItemBusiness orderItemBusiness;

        public MainForm(IProductBusiness _productBusiness, ICustomerBusiness _customerBusiness, IOrderBusiness _orderBusiness, IOrderItemBusiness _orderItemBusiness)
        {
            this.productBusiness = _productBusiness;
            this.customerBusiness = _customerBusiness;
            this.orderBusiness = _orderBusiness;
            this.orderItemBusiness = _orderItemBusiness;
            InitializeComponent();
        }

        private Order o;

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Product> results = this.productBusiness.GetAllProducts();

            dataGridView1.Columns["Id"].DataPropertyName = "ProductID";
            dataGridView1.Columns["ColumnName"].DataPropertyName = "Name";
            dataGridView1.Columns["ColumnPrice"].DataPropertyName = "Price";
            dataGridView1.Columns["ColumnSize"].DataPropertyName = "Size";
            dataGridView1.Columns["ColumnDescription"].DataPropertyName = "Description";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = results;
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
        public static Customer currentCustomer;
        decimal GrdTotal = 0;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxQuantity.Text == "")
            {
                MessageBox.Show("Please enter the quantity");
            }
            else
            {
                if(currentCustomer != null)
                {
                    decimal total = Convert.ToInt32(textBoxQuantity.Text) * Convert.ToDecimal(textBoxPrice.Text);
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridViewBill);
                    newRow.Cells[0].Value = textBoxProductId.Text;
                    newRow.Cells[1].Value = textBoxProductName.Text;
                    newRow.Cells[2].Value = textBoxPrice.Text;
                    newRow.Cells[3].Value = textBoxQuantity.Text;
                    newRow.Cells[4].Value = total;

                    dataGridViewBill.Rows.Add(newRow);

                    GrdTotal += total;

                    labelGrandTotal.Text = "" + GrdTotal;   

                }
                else
                {
                    MessageBox.Show("Please login!");
                }
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if(dataGridViewBill.Rows == null)
            {
                MessageBox.Show("Your bill is empty! ");
            }
            else
            {
                o = new Order()
                {
                    OrderDate = DateTime.Now,
                    DeliveryDate = DateTime.Now.AddDays(3),
                    CustomerID = currentCustomer.CoustomerID
                };

                this.orderBusiness.InsertOrders(o);
                o.OrderID = this.orderBusiness.GetNowOrder();

                foreach(DataGridViewRow row in dataGridViewBill.Rows)
                {
                    OrderItem oi = new OrderItem()
                    {
                        OrderID = o.OrderID,
                        ProductID = Convert.ToInt32(row.Cells[0].Value),
                        Quantity = Convert.ToInt32(row.Cells[3].Value)

                    };
                    this.orderItemBusiness.InsertOrderItems(oi);
                }
                dataGridViewBill.Rows.Clear();
                MessageBox.Show("Thank you for buying! See you again");
                GrdTotal = 0.0M;
                labelGrandTotal.Text = "";
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxProductName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBoxPrice.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBoxProductId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
