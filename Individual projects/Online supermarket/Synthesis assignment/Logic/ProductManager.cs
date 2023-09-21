using Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductManager
    {
        private List<Product> products;

        private readonly IDbProductHelper IdbProductHelper;

		public List<Product> Products { get => products; }

		public ProductManager(IDbProductHelper IdbProductHelper)
        {
            this.IdbProductHelper = IdbProductHelper
                ?? throw new ArgumentNullException(nameof(IdbProductHelper));
            products = new List<Product>();
        }

        public Product? Finder(int id)
        {
            Product foundProduct = new Product(IdbProductHelper.GetProductByID(id));
            return foundProduct;
        }

		public IEnumerable<Product> GetAllAvailable()
		{
			IEnumerable<ProductDTO> productDTOs = IdbProductHelper.GetAvailableProducts();
			List<Product> products = new List<Product>();
			foreach (ProductDTO p in productDTOs)
			{
				Product product = new Product(p);
				products.Add(product);
			}
			return products;
		}

		public IEnumerable<Product> GetAll()
        {
            IEnumerable<ProductDTO> productDTOs = IdbProductHelper.GetProducts();
            List<Product> products = new List<Product>();
            foreach (ProductDTO p in productDTOs)
            {
                Product product = new Product(p);
                products.Add(product);
            }
            return products;
        }

        public IEnumerable<Product> GetProductsBySubCategory(string subCategoryName)
        {
			IEnumerable<ProductDTO> productDTOs = IdbProductHelper.GetProductsBySubCategory(subCategoryName);
			List<Product> products = new List<Product>();
			foreach (ProductDTO p in productDTOs)
			{
				Product product = new Product(p);
				products.Add(product);
			}
			return products;
		}

        public bool AddProduct(string category, string subCategory, ProductStatus status, string name, decimal price, MeasureUnits measureUnit, string? image)
        {
			try
			{
				if (category != String.Empty && subCategory != String.Empty && status.ToString() != String.Empty
					&& name != String.Empty && price > 0 && measureUnit.ToString() != String.Empty && image != String.Empty)
				{
					string Status = status.ToString();
					string MeasureUnit = measureUnit.ToString();
					IdbProductHelper.AddProduct(category, subCategory, Status, name, price, MeasureUnit, image);
					return true;
				}
				else
				{
					throw new Exception("Please fill in all fields!");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			//string Status = status.ToString();
			//string MeasureUnit = measureUnit.ToString();
			//IdbProductHelper.AddProduct(category, subCategory, Status, name, price, MeasureUnit, image);
			//return true;
		}

		public bool AddProduct(Category category, Category subCategory, ProductStatus status, string name, decimal price, MeasureUnits measureUnit, string? image)
		{
			try
			{
				if (category.Name != String.Empty && subCategory.Name != String.Empty && status.ToString() != String.Empty
					&& name != String.Empty && price > 0 && measureUnit.ToString() != String.Empty && image != String.Empty)
				{
					string Status = status.ToString();
					string MeasureUnit = measureUnit.ToString();
					IdbProductHelper.AddProduct(category.Name, subCategory.Name, Status, name, price, MeasureUnit, image);
					return true;
				}
				else
				{
					throw new Exception("Please fill in all fields!");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool ModifyProduct(int id, string category, string subCategory, ProductStatus status, string name, decimal price, MeasureUnits measureUnit, string? image)
        {
            try
            {
				if (id != -1 && category != String.Empty && status.ToString() != String.Empty 
                    && name != String.Empty && name != null && price > 0 && measureUnit.ToString() != String.Empty && image != String.Empty)
				{
					IdbProductHelper.UpdateProduct(id, category, subCategory, status.ToString(), name, price, measureUnit.ToString(), image);
					return true;
				}
                else
                {
					throw new Exception("Please fill in all fields!");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

        public bool ModifyProductStatus(int id, string newStatus)
        {
            try
            {
				if (newStatus != String.Empty && Enum.TryParse(newStatus, out ProductStatus test) == true && id != -1)
				{
					IdbProductHelper.ModifyProductStatus(id, newStatus);
                    return true;
				}
				else
				{
					throw new Exception("Invalid data!");
				}
			}
            catch(Exception ex)
            {
				throw new Exception(ex.Message);
			}
        }
    }
}
