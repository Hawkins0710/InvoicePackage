
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InvoicePackage.Interfaces;
using InvoicePackage.Models;
using System.Diagnostics;

namespace InvoicePackage.Controllers
{
    [Produces("application/json")]
    [Route("api/invoice")]
    public class InvoiceController : Controller
    {
        private readonly InvoiceRepositoryInterface _invoiceRepository;

        public InvoiceController(InvoiceRepositoryInterface invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;

        }

        //Get api/invoice
        [HttpGet]
        public Task<IEnumerable<Invoice>> Get()
        {
            return GetInvoice();
        }

        private async Task<IEnumerable<Invoice>> GetInvoice()
        {
            var inv = _invoiceRepository.GetAllinvoices();
            return await _invoiceRepository.GetAllinvoices();
        }

        // GET api/invoices/5
        [HttpGet("{ID}")]
        public Task<Invoice> Get(string id)
        {
            return GetInvoiceById(id);
        }

        private async Task<Invoice> GetInvoiceById(string id)
        {
            return await _invoiceRepository.GetInvoice(id) ?? new Invoice();
        }

        // POST api/invoice
        [HttpPost]
        public async Task<string> Post([FromBody]Invoice invoice)
        {
            await _invoiceRepository.AddInvoice(invoice);
            return "";

        }

        // PUT api/invoice/5
        [HttpPut("{ID}")]
        public async Task<string> Put(string id, [FromBody] Invoice invoice)
        {
            if (string.IsNullOrEmpty(id))
                return "Invalid ID";

            return await _invoiceRepository.UpdateInvoice(id, invoice);
        }

        // DELETE api/invoice/
        [HttpDelete("{ID}")]
        public async Task<string> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return "Invalid ID";

            await _invoiceRepository.RemoveInvoice(id);
            return "";
        }


    }
}