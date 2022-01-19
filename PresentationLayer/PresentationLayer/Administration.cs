using Shared.Interfaces.Business;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Administration : Form
    {
        private readonly IProductBusiness productBusiness;
        public Administration(IProductBusiness _productBusiness)
        {
            this.productBusiness = _productBusiness;
            InitializeComponent();
        }

        private void Administration_Load(object sender, EventArgs e)
        {
            List<Product> results = this.productBusiness.GetAllProducts();
            dataGridView1.Columns["Id"].DataPropertyName = "ProductID";
            dataGridView1.Columns["ColumnName"].DataPropertyName = "Name";
            dataGridView1.Columns["ColumnPrice"].DataPropertyName = "Price";
            dataGridView1.Columns["ColumnSize"].DataPropertyName = "Size";
            dataGridView1.Columns["ColumnDescription"].DataPropertyName = "Description";
            dataGridView1.Columns["ColumnCategoryId"].DataPropertyName = "CategoryID";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = results;
        }

        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog() {  Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false})
            {
                if(openFile.ShowDialog() == DialogResult.OK)
                {
                    labelImage.Text = openFile.FileName;
                    pictureBox1.Image = Image.FromFile(labelImage.Text);
                }
            }
        }
    

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            try
            {
                p.Name = textBoxProductName.Text;
                p.Price = Convert.ToDecimal(textBoxPrice.Text);
                p.Size = Convert.ToInt32(textBoxSize.Text);
                p.Description = textBoxDescription.Text;
                p.CategoryID = Convert.ToInt32(textBoxCategoryId.Text);
                p.ProductImage = ConvertImageToBinary(Image.FromFile(labelImage.Text));

            }
            catch
            {
                MessageBox.Show("Incorrect format, try again!");
                return;
            }

            if (this.productBusiness.InsertProducts(p))
            {
                textBoxProductName.Text = "";
                textBoxPrice.Text = "";
                textBoxSize.Text = "";
                textBoxDescription.Text = "";
                textBoxCategoryId.Text = "";
                labelImage.Text = "";
                pictureBox1.Image = null;
                dataGridView1.DataSource = this.productBusiness.GetAllProducts();

                MessageBox.Show("Succesfully save data!");
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxProductId.SelectedText == null)
            {
                MessageBox.Show("Please enter valid number!");
            }
            else
            {
                int id = Convert.ToInt32(textBoxProductId.Text);
                Product p = new Product();
                p.ProductID = id;
                p.Name = textBoxProductName.Text;
                p.Price = Convert.ToDecimal(textBoxPrice.Text);
                p.Size = Convert.ToInt32(textBoxSize.Text);
                p.Description = textBoxDescription.Text;
                p.CategoryID = Convert.ToInt32(textBoxCategoryId.Text);

                this.productBusiness.UpdateCProductsById(p);
                MessageBox.Show("Product is updated!");
                dataGridView1.DataSource = this.productBusiness.GetAllProducts();

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(textBoxProductId == null)
            {
                MessageBox.Show("Please enter id!");
            }
            else
            {
                int id = Convert.ToInt32(textBoxProductId.Text);
                if (this.productBusiness.DeleteProductsById(id))
                {
                    MessageBox.Show("Product is deleted!");

                    textBoxProductId.Clear();

                    textBoxProductName.Text = "";
                    textBoxPrice.Text = "";
                    textBoxSize.Text = "";
                    textBoxDescription.Text = "";
                    textBoxCategoryId.Text = "";
                    labelImage.Text = "";
                    pictureBox1.Image = null;

                    dataGridView1.DataSource = this.productBusiness.GetAllProducts();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxProductId.Text = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
            textBoxProductName.Text = dataGridView1.SelectedRows[0].Cells["ColumnName"].Value.ToString();
            textBoxPrice.Text = dataGridView1.SelectedRows[0].Cells["ColumnPrice"].Value.ToString();
            textBoxSize.Text = dataGridView1.SelectedRows[0].Cells["ColumnSize"].Value.ToString();
            textBoxDescription.Text = dataGridView1.SelectedRows[0].Cells["ColumnDescription"].Value.ToString();
            textBoxCategoryId.Text = dataGridView1.SelectedRows[0].Cells["ColumnCategoryId"].Value.ToString();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            List<Product> list = this.productBusiness.GetAllProducts();
            list = list.Where(p => p.Name.ToLower().Contains(textBoxSearch.Text.ToLower())).ToList();
            dataGridView1.DataSource = list;
        }
    }
} 
