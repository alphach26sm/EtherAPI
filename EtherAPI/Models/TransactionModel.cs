using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EtherAPI
{
    public class TransactionModel
    {
        public string From_PrivateKey { get; set; }
        public string To { get; set; }
        public int Amount { get; set; }
    }
}