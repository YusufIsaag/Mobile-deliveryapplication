using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_deliveryapplication.Models
{
    public class DeliveryStateModel
    {
        public int Id { get; set; }
        public int State { get; set; }
        public DateTime DateTime { get; set; }
        public int OrderId { get; set; }
        public int DeliveryServiceId { get; set; }
        public DeliveryServiceModel DeliveryService { get; set; }
    }
}
