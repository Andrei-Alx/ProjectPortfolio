using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OrderProductDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public OrderProductDTO() { }

        public OrderProductDTO(int id, ProductDTO product, int quantity, decimal price)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            Price = price;
        }
    }
}
