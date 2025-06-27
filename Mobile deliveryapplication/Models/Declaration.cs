using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_deliveryapplication.Models
{
    public class Declaration
    {
        public DateTime Datum { get; set; }
        public string Omschrijving { get; set; }
        public decimal Bedrag { get; set; }
        public string Type { get; set; } // Type van de declaratie (bijv. "Reiskosten", "Maaltijden", "Overige")
        public string FotoPad { get; set; } // Pad naar de foto die bij de declaratie hoort
        public string Status { get; set; } // Status van de declaratie (bijv. "In behandeling", "Goedgekeurd", "Afgewezen")
        public DateTime ToegevoegdOp { get; set; }


    }
}
