using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductDTO
    {
		public ProductDTO()
		{
		}

		public ProductDTO(int id, string name, decimal price, CategoryDTO category, CategoryDTO? subCategory, string productStatus, string measureUnit, string? image)
		{
			Id = id;
			Name = name;
			Price = price;
			Category = category;
			SubCategory = subCategory;
			ProductStatus = productStatus;
			MeasureUnit = measureUnit;
			Image = image;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public CategoryDTO Category { get; set; }
		public CategoryDTO? SubCategory { get; set; }
		public string ProductStatus { get; set; }
		public string MeasureUnit { get; set; }
		public string? Image { get; set; }
	}
}
