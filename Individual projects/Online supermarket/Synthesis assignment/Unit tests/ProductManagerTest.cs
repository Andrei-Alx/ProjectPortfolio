using Data;
using Data.MockClasses;
using Logic;

namespace Unit_tests
{
	[TestClass]
	public class ProductManagerTest
	{
		[TestMethod]
		public IDbProductHelper CreateTestHelper()
		{
			return new MockProductHelper();
		}

		[TestMethod]
		public void AddProduct() 
		{
			//Arrange
			ProductManager productManager = new ProductManager(CreateTestHelper());
			//Act
			bool testResult = productManager.AddProduct("Vegetables and Fruits", "Fruit", ProductStatus.Available, "Peach", 1, MeasureUnits.Pack, "img");
			//Act
			Assert.IsTrue(testResult);
		}

		[TestMethod]
		public void AddProductSuccess()
		{
			//Arrange
			ProductManager productManager = new ProductManager(CreateTestHelper());
			Category category = new Category();
			category.Id = 1;
			category.Name = "Vegetables and Fruits";
			Category subCategory = new Category();
			subCategory.Id = 2;
			subCategory.Name = "Fruit";
			subCategory.ParentId = 2;
			//Act
			bool result = productManager.AddProduct(category.Name, subCategory.Name, ProductStatus.Available, "Peach", 2, MeasureUnits.Piece, "testImage");
			//Assert
			Assert.IsTrue(result);
		}
		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void AddProductEmptyException()
		{
			//Arrange
			ProductManager productManager = new ProductManager(CreateTestHelper());
			Category cat = new Category();
			cat.Id = 1;
			cat.Name = "Vegetables and Fruits";
			Category scat = new Category();
			scat.Id = 2;
			scat.Name = "Fruit";
			scat.ParentId = 2;
			//Act
			bool throwEmptyEx = productManager.AddProduct(cat, scat, ProductStatus.Available, "", 2, MeasureUnits.Piece, "testImage");
		}
		[TestMethod]
		public void ModifyProductSuccess()
		{
			//Arrange
			ProductManager productManager = new ProductManager(CreateTestHelper());
			Category cat = new Category();
			cat.Id = 1;
			cat.Name = "Meat";
			Category scat = new Category();
			scat.Id = 2;
			scat.Name = "Pork";
			scat.ParentId = 1;
			Product product = new Product();
			product.Id = 20; product.Name = "Steak"; product.Price = 3; product.Category = cat; product.SubCategory = scat; 
			product.ProductStatus = ProductStatus.Available; product.Unit = MeasureUnits.Piece; product.Image = "testImage";
			//Act
			bool resultTrue = productManager.ModifyProduct(product.Id, product.Category.Name, product.SubCategory.Name,
				ProductStatus.Available, product.Name, 8, product.Unit, product.Image);
			//Assert
			Assert.IsTrue(resultTrue);
		}
		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void ModifyProductEmptyException()
		{
			//Arrange
			ProductManager productManager = new ProductManager(CreateTestHelper());
			Category cat = new Category();
			cat.Id = 1;
			cat.Name = "Meat";
			Category scat = new Category();
			scat.Id = 2;
			scat.Name = "Pork";
			scat.ParentId = 1;
			Product product = new Product();
			product.Id = 20; product.Name = "Steak"; product.Price = 3; product.Category = cat; product.SubCategory = scat;
			product.ProductStatus = ProductStatus.Available; product.Unit = MeasureUnits.Piece; product.Image = "testImage";
			//Act
			productManager.ModifyProduct(product.Id, product.Category.Name, product.SubCategory.Name,
				ProductStatus.Available, "", 8, product.Unit, product.Image);
		}
		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void ModifyProductNullProductException()
		{
			//Arrange
			ProductManager productManager = new ProductManager(CreateTestHelper());
			Category cat = new Category();
			cat.Id = 1;
			cat.Name = "Meat";
			Category scat = new Category();
			scat.Id = 2;
			scat.Name = "Pork";
			scat.ParentId = 1;
			Product product = new Product();
			product.Id = 20; product.Name = "Steak"; product.Price = 3; product.Category = cat; product.SubCategory = scat;
			product.ProductStatus = ProductStatus.Available; product.Unit = MeasureUnits.Piece; product.Image = "testImage";
			//Act
			productManager.ModifyProduct(product.Id, product.Category.Name, product.SubCategory.Name,
				ProductStatus.Available, null, 8, product.Unit, product.Image);
		}

		[TestMethod]
		public void ModifyProductStatusSuccess()
		{
			//Arrange
			ProductManager productManager = new ProductManager(CreateTestHelper());
			Category cat = new Category();
			cat.Id = 1;
			cat.Name = "Vegetables and Fruits";
			Category scat = new Category();
			scat.Id = 2;
			scat.Name = "Fruit";
			scat.ParentId = 2;
			productManager.AddProduct(cat, scat, ProductStatus.Available, "Peach", 2, MeasureUnits.Piece, "testImage");
			//Act
			bool result = productManager.ModifyProductStatus(10, "Unavailable");
			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void ModifyProductStatusNotFoundException()
		{
			//Arrange
			ProductManager productManager = new ProductManager(CreateTestHelper());
			Category cat = new Category();
			cat.Id = 1;
			cat.Name = "Vegetables and Fruits";
			Category scat = new Category();
			scat.Id = 2;
			scat.Name = "Fruit";
			scat.ParentId = 2;
			productManager.AddProduct(cat, scat, ProductStatus.Available, "Peach", 2, MeasureUnits.Piece, "testImage");
			//Act
			productManager.ModifyProductStatus(10, "Unav");
		}
	}
}