using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic
{
    public class Product
    {
        public Product()
        {

        }
        public Product(ProductDTO productDTO)
        {
            Id = productDTO.Id;
            Name = productDTO.Name;
            Price = productDTO.Price;
            Category = new Category(productDTO.Category);
            if (productDTO.SubCategory != null)
            {
                SubCategory = new Category(productDTO.SubCategory);
            }
            else { SubCategory= null; }
            ProductStatus = SetTypeStatus(productDTO.ProductStatus);
            Unit = SetTypeUnit(productDTO.MeasureUnit);
            Image = productDTO.Image;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Category? SubCategory { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public MeasureUnits Unit { get; set; }
        public string? Image { get; set; }

        public override string ToString()
        {
            return "Product: " + this.Id + " " + this.Name + " " + this.Price + " euros " + this.Category.Name + " " + this.ProductStatus + " " +
                  " " + this.Unit.ToString() + " " + this.Image;
        }

		public ProductStatus SetTypeStatus(string type)
		{
			ProductStatus setType = ProductStatus.Available;

			switch (type)
			{
				case "Available":
					setType = ProductStatus.Available;
					break;

				case "Unavailable":
					setType = ProductStatus.Unavailable;
					break;
			}
			return setType;
		}

		public string GetTypeStatus(ProductStatus type)
		{
			string setType = "Available";
			switch (type)
			{
				case ProductStatus.Available:
					setType = "Available";
					break;

				case ProductStatus.Unavailable:
					setType = "Unavailable";
					break;
			}
			return setType;
		}

		public MeasureUnits SetTypeUnit(string type)
		{
			MeasureUnits setType = MeasureUnits.Piece;

			switch (type)
			{
				case "Piece":
					setType = MeasureUnits.Piece;
					break;

				case "Kg":
					setType = MeasureUnits.Kg;
					break;

				case "Box":
					setType = MeasureUnits.Box;
					break;

				case "Grams":
					setType = MeasureUnits.Grams;
					break;

				case "Pack":
					setType = MeasureUnits.Pack;
					break;

				case "Can":
					setType = MeasureUnits.Can;
					break;

				case "Bottle":
					setType = MeasureUnits.Bottle;
					break;
			}
			return setType;
		}

		public string GetTypeUnit(MeasureUnits type)
		{
			string setType = "Piece";
			switch (type)
			{
				case MeasureUnits.Piece:
					setType = "Piece";
					break;

				case MeasureUnits.Kg:
					setType = "Kg";
					break;
				case MeasureUnits.Box:
					setType = "Box";
					break;
				case MeasureUnits.Grams:
					setType = "Grams";
					break;
				case MeasureUnits.Pack:
					setType = "Pack";
					break;
				case MeasureUnits.Can:
					setType = "Can";
					break;
				case MeasureUnits.Bottle:
					setType = "Bottle";
					break;
			}
			return setType;
		}
	}
}
