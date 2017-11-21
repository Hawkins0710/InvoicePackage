using System.Collections.Generic;
using System.Threading.Tasks;
using InvoicePackage.Models;
using MongoDB.Driver;

namespace InvoicePackage.Interfaces
{
    public interface InvoiceRepositoryInterface
    {
        Task<IEnumerable<Invoice>> GetAllinvoices();
        Task<Invoice> GetInvoice(string id);
        Task AddInvoice(Invoice invoice);
        Task<DeleteResult> RemoveInvoice(string id);
        Task<string> UpdateInvoice(string id, Invoice invoice);

    }
}

