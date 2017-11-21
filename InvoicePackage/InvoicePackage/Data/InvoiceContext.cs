using MongoDB.Driver;
using InvoicePackage.Models;
using Microsoft.Extensions.Options;

namespace InvoicePackage.Data
{
    public class InvoiceContext
    {
        private readonly IMongoDatabase _database = null;

        public InvoiceContext(IOptions<Settings> settings)
        {
           
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Invoice> Invoices
        {
            get
            {
                return _database.GetCollection<Invoice>("invoicePackage");
            }
        }
    }
  
}
