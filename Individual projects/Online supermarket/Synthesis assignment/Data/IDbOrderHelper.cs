namespace Data
{
    public interface IDbOrderHelper
    {
        List<OrderDTO> GetOrders();
        void UpdateStatus(int id, string newStatus);
        OrderDTO GetOrderByID(int id);
        void CreateOrder(UserDTO customer, List<ProductDTO> boughtItems, decimal totalPrice, string status, HomeDeliveryDTO? HDDTO, PickupDeliveryDTO? PUDTO, string orderTime);
        Dictionary<string, int> GetOrdersPerTimeSlot();
		int GetLastOrderID();
        List<OrderProductDTO> GetOrderProducts(int orderId);
    }
}