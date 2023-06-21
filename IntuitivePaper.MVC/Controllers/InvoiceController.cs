using IntuitivePaper.Application.Invoice.Queries.GetAllInvoices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntuitivePaper.MVC.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var invoices = await _mediator.Send(new GetAllInvoicesQuery());
            return View(invoices);
        }
    }
}
