using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace InvoicePackage.Models
{
    public class Invoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderRef { get; set; }
        public string ODate { get; set; }
        public string OTotal { get; set; }
        public string ID { get; set; }
        public string IID { get; set; }
        public string IDate { get; set; }
        public string CID { get; set; }
        public string CName { get; set; }
        public string CAddress { get; set; }
        public string ITotal { get; set; }
        public Boolean Pending { get; set; }
    }
}
