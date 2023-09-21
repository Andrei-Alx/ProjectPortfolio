using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synthesis_assignment
{
    public partial class WorkerDashboard : Form
    {

        private ProductManager productManager;
        private IDbProductHelper dbProductHelper;
        private IDbOrderHelper dbOrderHelper;
        private CategoryManager categoryManager;
        public WorkerDashboard()
        {
            InitializeComponent();
            dbProductHelper = new DbProductHelper();
            productManager = new ProductManager(dbProductHelper);
            dbOrderHelper = new DbOrderHelper();
            categoryManager = new CategoryManager();
            UpdateCategories();
            cbProductUnit.DataSource = Enum.GetValues(typeof(MeasureUnits));
            cbProductStatus.DataSource = Enum.GetValues(typeof(ProductStatus));
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if(tbProductName.Text != String.Empty && tbProductPrice.Text != String.Empty && cbProductCategory.Text != String.Empty && 
                    cbProductSubCategory.Text != String.Empty && cbProductUnit.Text != String.Empty && tbImage.Text != String.Empty)
                {
                    string name = Convert.ToString(tbProductName.Text);
                    string category = (string)cbProductCategory.Text;
                    string subCategory = (string)cbProductCategory.Text;
                    string image = Convert.ToString(tbImage.Text);
                    if (Decimal.TryParse(tbProductPrice.Text, out decimal testPrice) && Enum.TryParse(cbProductUnit.Text, out MeasureUnits testUnit))
                    {
                        decimal price = Convert.ToDecimal(tbProductPrice.Text);
                        MeasureUnits unit = (MeasureUnits)cbProductCategory.SelectedIndex;
                        ProductStatus status = (ProductStatus)cbProductStatus.SelectedIndex;
                        productManager.AddProduct(category, subCategory, status, name, price, unit, image);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifyProductData_Click(object sender, EventArgs e)
        {
            if (tbProductName.Text != String.Empty && tbProductPrice.Text != String.Empty && cbProductCategory.Text != String.Empty && cbProductSubCategory.Text != String.Empty &&
                   cbProductUnit.Text != String.Empty && tbImage.Text != String.Empty)
            {
                int id = Convert.ToInt32(tbId.Text);
                string name = Convert.ToString(tbProductName.Text);
                string category = (string)cbProductCategory.Text;
                string subCategory = (string)cbProductSubCategory.Text;
                string image = Convert.ToString(tbImage.Text);
                if (Decimal.TryParse(tbProductPrice.Text, out decimal testPrice) && Enum.TryParse(cbProductUnit.Text, out MeasureUnits testUnit))
                {
                    decimal price = Convert.ToDecimal(tbProductPrice.Text);
                    MeasureUnits unit = (MeasureUnits)cbProductCategory.SelectedIndex;
                    ProductStatus status = (ProductStatus)cbProductStatus.SelectedIndex;
                    productManager.ModifyProduct(id, category, subCategory, status, name, price, unit, image);
                }
            }
            else
            {
                MessageBox.Show("Fill in all fields!");
            }
        }

        public void UpdateSubCategories()
        {
            if (cbProductCategory.SelectedItem != null)
            {
                cbProductSubCategory.Items.Clear();
                foreach (Category category in categoryManager.GetAllCategories())
                {
                    if (category.Name == cbProductCategory.SelectedItem.ToString())
                    {
                        foreach (Category subcategory in categoryManager.GetSubCategories(category.Id))
                        {
                            cbProductSubCategory.Items.Add(subcategory.Name);
                        }
                    }
                }
            }
        }
        public void UpdateCategories()
        {
            cbProductCategory.Items.Clear();
            cbProductSubCategory.Items.Clear();

            foreach (Category category in categoryManager.GetAllCategories())
            {
                cbProductCategory.Items.Add(category.Name);
            }
        }
        private void cbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSubCategories();
        }

        private void WorkerDashboard_Load(object sender, EventArgs e)
        {
            lbProductDisplay.Items.Clear();
            foreach (Product product in productManager.GetAll())
            {
                lbProductDisplay.Items.Add(product.ToString());
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            lbProductDisplay.Items.Clear();
            foreach (Product product in productManager.GetAll())
            {
                lbProductDisplay.Items.Add(product.ToString());
            }
        }

        private void lbProductDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? productInfo = lbProductDisplay.SelectedItem.ToString();
            string[] subs = productInfo.Split();
            Product? foundProduct = productManager.Finder(Convert.ToInt32(tbId.Text = subs[1]));
            if (foundProduct != null)
            {
                tbId.Text = foundProduct.Id.ToString();
                tbProductName.Text = foundProduct.Name.ToString();
                tbProductPrice.Text = foundProduct.Price.ToString();
                cbProductCategory.Text = foundProduct.Category.Name;
                if (foundProduct.SubCategory != null)
                {
                    cbProductSubCategory.Text = foundProduct.SubCategory.Name;
                }
                else
                {
                    cbProductSubCategory.Text = "No sub category found!";
                }
                cbProductStatus.Text = foundProduct.ProductStatus.ToString();
                cbProductUnit.Text = foundProduct.Unit.ToString();
                if (foundProduct.Image != null)
                {
                    tbImage.Text = foundProduct.Image.ToString();
                }
                else
                {
                    tbImage.Text = "No image link found!";
                }
            }
        }

        private void btnSetStatus_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbId.Text);
            string newStatus = cbProductStatus.Text;
            productManager.ModifyProductStatus(id, newStatus);
        }
    }
}
