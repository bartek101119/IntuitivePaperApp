﻿using AutoMapper;
using IntuitivePaper.Application.Invoice.Commands.CreateInvoice;
using IntuitivePaper.Application.Invoice.Commands.EditInvoice;
using IntuitivePaper.Application.Invoice.Queries.GetAllInvoices;
using IntuitivePaper.Application.Invoice.Queries.GetByIdInvoice;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntuitivePaper.MVC.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public InvoiceController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var invoices = await _mediator.Send(new GetAllInvoicesQuery());
            return View(invoices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInvoiceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [Route("Invoice/{id}/Edit")]
        public async Task<IActionResult> Edit(long id)
        {
            var invoiceDto = await _mediator.Send(new GetByIdInvoiceQuery(id));

            var model = _mapper.Map<EditInvoiceCommand>(invoiceDto);

            return View(model);
        }

        [HttpPost]
        [Route("Invoice/{id}/Edit")]
        public async Task<IActionResult> Edit(long id, EditInvoiceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [Route("Invoice/{id}/Details")]
        public async Task<IActionResult> Details(long id)
        {
            var invoiceDto = await _mediator.Send(new GetByIdInvoiceQuery(id));

            return View(invoiceDto);
        }
    }
}
