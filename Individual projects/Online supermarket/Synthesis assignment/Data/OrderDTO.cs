using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class OrderDTO
	{
		private int id;
		private UserDTO customer;
		private List<OrderProductDTO> products;
		private string status;
		private HomeDeliveryDTO? homeDelivery;
		private PickupDeliveryDTO? pickUp;
		private List<ProductDTO> boughtItems;
		private decimal totalPrice;
		private string orderTime;


		public OrderDTO()
		{
		}
		public OrderDTO(UserDTO customer, List<ProductDTO> boughtItems, decimal totalPrice, string status, HomeDeliveryDTO homeDelivery, string orderTime)
		{
			this.customer = customer;
			this.boughtItems = boughtItems;
			this.totalPrice = totalPrice;
			this.homeDelivery = homeDelivery;
			this.status = status;
			this.orderTime = orderTime;
		}
		public OrderDTO(UserDTO customer, List<ProductDTO> boughtItems, decimal totalPrice, string status, PickupDeliveryDTO pickUp, string orderTime)
		{
			this.customer = customer;
			this.boughtItems = boughtItems;
			this.totalPrice = totalPrice;
			this.pickUp = pickUp;
			this.status = status;
			this.orderTime = orderTime;
		}

		public int Id { get; set; }
		public string OrderTime { get; set; }
		public UserDTO Customer { get; set; }
		public List<OrderProductDTO> Products { get; set; }
		public List<ProductDTO> ProductDTOs { get; set; }
		public HomeDeliveryDTO? HomeDelivery{ get; set; }
		public PickupDeliveryDTO? PickupDelivery { get; set; }
		public decimal Total { get; set; }
		public string Status { get; set; }
	}
}
