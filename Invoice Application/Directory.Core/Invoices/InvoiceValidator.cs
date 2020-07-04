using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.Core.Invoices
{
    interface InvoiceValidator
    {
        public bool isValidInvoice { get; set; }
    }
}
