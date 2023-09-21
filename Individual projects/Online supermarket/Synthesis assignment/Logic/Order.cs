using Data;

namespace Logic
{
	public class Order
	{
		public int Id { get; set; }
		public User Customer { get; set; }
		public string Time { get; set; }
		public List<OrderProduct> Products { get; set; }
		public List<Product> BoughtProducts { get; set; }
		public decimal Total { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public DeliveryOption DeliveryOption { get; set; }

		public Order()
		{

		}

		public Order(List<OrderProduct> products, decimal total, string time, DeliveryOption deliveryOption)
		{
			Products = products;
			Total = total;
			Time = time;
			OrderStatus = OrderStatus.Preparing;
			DeliveryOption = deliveryOption;
		}

		public Order(OrderDTO order)
		{
			BoughtProducts = new List<Product>();
			Id = order.Id;
			User u = new User(order.Customer);
			u.Id = order.Customer.Id;
			Customer = u;
			foreach (ProductDTO p in order.ProductDTOs)
			{
				BoughtProducts.Add(new Product(p));
			}
			Total = order.Total;
			OrderStatus = SetType(order.Status);
			if (order.HomeDelivery != null)
			{
				DeliveryOption = new HomeDelivery(order.HomeDelivery);
			}
			else if (order.PickupDelivery != null)
			{
				DeliveryOption = new PickupDelivery(order.PickupDelivery);
			}
		}
		public Order(User customer, List<Product> boughtItems, decimal totalPrice, DeliveryOption deliveryOption, string status, string orderTime)
		{
			this.Customer = customer;
			this.BoughtProducts = boughtItems;
			this.Total = totalPrice;
			this.DeliveryOption = deliveryOption;
			this.OrderStatus = SetType(status);
			this.Time = orderTime;
		}
		public OrderStatus SetType(string type)
		{
			OrderStatus setType = OrderStatus.Preparing;

			switch (type)
			{
				case "Preparing":
					setType = OrderStatus.Preparing;
					break;

				case "AwaitingShipment":
					setType = OrderStatus.AwaitingShipment;
					break;

				case "Shipped":
					setType = OrderStatus.Shipped;
					break;

				case "Delivered":
					setType = OrderStatus.Delivered;
					break;
			}
			return setType;
		}

		public string GetType(OrderStatus type)
		{
			string setType = "Preparing";
			switch (type)
			{
				case OrderStatus.Preparing:
					setType = "Preparing";
					break;

				case OrderStatus.AwaitingShipment:
					setType = "Awaiting shipment";
					break;

				case OrderStatus.Shipped:
					setType = "Shipped";
					break;

				case OrderStatus.Delivered:
					setType = "Delivered";
					break;
			}
			return setType;
		}

	}
}