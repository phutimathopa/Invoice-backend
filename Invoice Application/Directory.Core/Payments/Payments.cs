using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.Core.Payments
{
    class payment
    {
        public bool isPaymentmethod { get; set; }

        //Relation
        public int? idClient { get; set; }
    }
}
