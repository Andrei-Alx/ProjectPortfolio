using Data;
using Data.MockClasses;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_tests
{
	[TestClass]
	public class OrderManagerTests
	{
		[TestMethod]
		private IDbOrderHelper CreateTestRepo()
		{
			return new MockOrderHelper();
		}

		[TestMethod]
		public void CreateOrderSuccess()
		{
			//Arrange
			OrderManager orderManager = new OrderManager(CreateTestRepo());
			User customer = new User();
			List<Product> products = new List<Product>();
			HomeDelivery homeDelivery = new HomeDelivery();
			homeDelivery.Fullname = "Name";
			homeDelivery.Adress = "Adress";
			homeDelivery.Email = "email@mail.com";
			PickupDelivery pickUp = new PickupDelivery();
			pickUp.Fullname = "Name";
			pickUp.Store = "Test";
			pickUp.Email = "email@mail.com";
			//Act
			bool isTrueDelivery = orderManager.AddOrder(customer, products, 20, homeDelivery, null, "Preparing", "13:45");
			bool isTruePickUp = orderManager.AddOrder(customer, products, 20, null, pickUp, "Preparing", "13:00");
			//Assert
			Assert.IsTrue(isTrueDelivery);
			Assert.IsTrue(isTruePickUp);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void CreateOrderNullCustomer()
		{
			//Arrange
			OrderManager orderManager = new OrderManager(CreateTestRepo());
			User customer = null;
			List<Product> products = new List<Product>();
			HomeDelivery homeDelivery = new HomeDelivery();
			PickupDelivery pickUp = new PickupDelivery();
			//Act
			orderManager.AddOrder(customer, products, 20, homeDelivery, null, "Preparing", "19:00");
			orderManager.AddOrder(customer, products, 20, null, pickUp, "Preparing", "08:00");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void CreateOrderNullOrderInfo()
		{
			//Arrange
			OrderManager orderManager = new OrderManager(CreateTestRepo());
			User customer = new User();
			List<Product> products = new List<Product>();
			//Act
			orderManager.AddOrder(customer, products, 20, null, null, "Preparing", "13:45");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void CreateOrderNullOrderTime()
		{
			//Arrange
			OrderManager orderManager = new OrderManager(CreateTestRepo());
			User customer = new User();
			List<Product> products = new List<Product>();
			HomeDelivery homeDelivery = new HomeDelivery();
			PickupDelivery pickUp = new PickupDelivery();
			//Act
			orderManager.AddOrder(customer, products, 20, homeDelivery, null, "Preparing", "");
			orderManager.AddOrder(customer, products, 20, null, pickUp, "Preparing", "");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void CreateOrderFullTimeSlot()
		{
			//Arrange
			OrderManager orderManager = new OrderManager(CreateTestRepo());
			User customer = new User();
			List<Product> products = new List<Product>();
			HomeDelivery homeDelivery = new HomeDelivery();
			PickupDelivery pickUp = new PickupDelivery();
			//Act
			orderManager.AddOrder(customer, products, 20, homeDelivery, null, "Preparing", "9:00");
		}

		[TestMethod]
		public void ModifyStatusSuccess()
		{
			//Arrange
			OrderManager orderManager = new OrderManager(CreateTestRepo());
			User customer = new User();
			List<Product> products = new List<Product>();
			HomeDelivery homeDelivery = new HomeDelivery();
			Order order = new Order(customer, products, 20, homeDelivery, "Preparing", "13:45");
			//Act
			orderManager.UpdateOrderStatus(order.Id, "Preparing");
			//Assert
			Assert.AreEqual("Preparing", order.OrderStatus.ToString());
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void ModifyStatusWrongStatus()
		{
			//Arrange
			OrderManager orderManager = new OrderManager(CreateTestRepo());
			User customer = new User();
			List<Product> products = new List<Product>();
			HomeDelivery homeDelivery = new HomeDelivery();
			Order order = new Order(customer, products, 20, homeDelivery, "Preparing", "13:45");
			//Act
			orderManager.UpdateOrderStatus(order.Id, "WrongStatus");
		}
	}
}
