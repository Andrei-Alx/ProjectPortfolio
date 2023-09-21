using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MockClasses
{
	public class MockProductHelper : IDbProductHelper
	{
		List<ProductDTO> productDTOs = new List<ProductDTO>();

		public void AddProduct(string category, string subCategory, string status, string name, decimal price, string measureUnit, string? image)
		{
			
		}

		public IEnumerable<ProductDTO> GetAvailableProducts()
		{
			IEnumerable<ProductDTO> productDTOs;
			productDTOs = new List<ProductDTO>();
			return productDTOs;
		}

		public ProductDTO? GetProductByID(int id)
		{
			ProductDTO result = new ProductDTO();
			CategoryDTO category = new CategoryDTO();
			CategoryDTO subcategory = new CategoryDTO();
			result.Category = category;
			result.SubCategory = subcategory;
			return result;
		}

		public IEnumerable<ProductDTO> GetProducts()
		{
			IEnumerable<ProductDTO> productDTOs;
			productDTOs = new List<ProductDTO>();
			return productDTOs;
		}

		public IEnumerable<ProductDTO> GetProductsBySubCategory(string subCategoryName)
		{
			IEnumerable<ProductDTO> productDTOs; 
			productDTOs = new List<ProductDTO>();
			return productDTOs;
		}

		public void ModifyProductStatus(int id, string status)
		{
			
		}

		public void UpdateProduct(int id, string category, string subCategory, string status, string name, decimal price, string measureUnit, string? image)
		{
			
		}
	}
}
