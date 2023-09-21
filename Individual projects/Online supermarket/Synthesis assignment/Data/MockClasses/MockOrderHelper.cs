using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MockClasses
{
	public class MockOrderHelper : IDbOrderHelper
	{
		List<OrderDTO> orderDTOs = new List<OrderDTO>();

		public void CreateOrder(UserDTO customer, List<ProductDTO> boughtItems, decimal totalPrice, string status, HomeDeliveryDTO? HDDTO, PickupDeliveryDTO? PUDTO, string orderTime)
		{
			
		}

		public int GetLastOrderID()
		{
			return 0;
		}

		public OrderDTO GetOrderByID(int id)
		{
			OrderDTO orderDTO = new OrderDTO();
			return orderDTO;
		}

		public List<OrderProductDTO> GetOrderProducts(int orderId)
		{
			return null;
		}

		public List<OrderDTO> GetOrders()
		{
			return orderDTOs;
		}

		public IEnumerable<OrderDTO> GetOrdersPerCustomer(int userId)
		{
			throw new NotImplementedException();
		}

		public Dictionary<string, int> GetOrdersPerTimeSlot()
		{	
			//Fake dictionary data added to test if you can't add order in a full timeslot
			Dictionary<string, int> keyValuePairs;
			keyValuePairs = new Dictionary<string, int>();
			keyValuePairs.Add("9:00", 5);
			return keyValuePairs;
		}

		public void UpdateStatus(int id, string newStatus)
		{
			
		}
	}
}
