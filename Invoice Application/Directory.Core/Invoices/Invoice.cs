using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.Core.Invoices
{
    class Invoice : Entity
    {
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public float Total { get; set; }
        public float GrandTotal { get; set; }
    }
}
