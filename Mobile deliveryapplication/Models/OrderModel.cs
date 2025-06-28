using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_deliveryapplication.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }
        public List<ProductModel> Products { get; set; }
        public List<DeliveryStateModel> DeliveryStates { get; set; }
    }
}
