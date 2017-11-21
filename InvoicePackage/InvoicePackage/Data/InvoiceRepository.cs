using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using InvoicePackage.Interfaces;
using InvoicePackage.Models;


namespace InvoicePackage.Data
{   //CRUD ops. Async access to database
    public class InvoiceRepository : InvoiceRepositoryInterface
    {
        private readonly InvoiceContext _context = null;

        public InvoiceRepository(IOptions<Settings> settings)
        {
            _context = new InvoiceContext(settings);
        }

        public async Task<IEnumerable<Invoice>> GetAllinvoices()
        {
            try
            {
                var test = _context.Invoices.Find(_ => true);
                return await _context.Invoices.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public async Task<Invoice> GetInvoice(string id)
        {
            var inv = Builders<Invoice>.Filter.Eq("ID", id);

            try
            {
                return await _context.Invoices
                                .Find(inv)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
             
                throw ex;
            }
        }

        public async Task AddInvoice(Invoice invoice)
        {
            try
            {
                await _context.Invoices.InsertOneAsync(invoice);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public async Task<DeleteResult> RemoveInvoice(string id)
        {
            try
            {
                return await _context.Invoices.DeleteOneAsync(
                     Builders<Invoice>.Filter.Eq("InvoiceID", id));

            }
            catch (Exception ex)
            {
              
                throw ex;
            }
        }

        public async Task<string> UpdateInvoice(string id, Invoice invoice)
        {
            await _context.Invoices.ReplaceOneAsync(i => i.IID.Equals(id)
                                                             , invoice
                                                             , new UpdateOptions { IsUpsert = true });
            return " ";
        }
    }
}


