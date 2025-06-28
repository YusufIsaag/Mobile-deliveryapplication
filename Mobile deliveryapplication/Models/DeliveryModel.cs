using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_deliveryapplication.Models
{
    public class DeliveryModel
    {
        public int Id { get; set; }
        public int State { get; set; }
        public DateTime DateTime { get; set; }
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
    }
}