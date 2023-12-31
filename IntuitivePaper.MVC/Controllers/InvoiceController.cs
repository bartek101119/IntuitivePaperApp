﻿using AutoMapper;
using IntuitivePaper.Application.Invoice.Commands.CreateInvoice;
using IntuitivePaper.Application.Invoice.Commands.EditInvoice;
using IntuitivePaper.Application.Invoice.Commands.RemoveInvoice;
using IntuitivePaper.Application.Invoice.Queries.GetAllInvoices;
using IntuitivePaper.Application.Invoice.Queries.GetByIdInvoice;
using IntuitivePaper.Application.InvoiceItem.Commands.CreateInvoiceItem;
using IntuitivePaper.Application.InvoiceItem.Commands.RemoveInvoiceItem;
using IntuitivePaper.Application.InvoiceItem.Queries.GetAllInvoiceItem;
using IntuitivePaper.Domain.Interfaces;
using IntuitivePaper.MVC.Extensions;
using IntuitivePaper.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IntuitivePaper.MVC.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPdfService _pdfService;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IMediator mediator, IMapper mapper, IPdfService pdfService, IInvoiceRepository invoiceRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _pdfService = pdfService;
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GeneratePdf(long id)
        {
            var invoice = await _invoiceRepository.GetByIdWithItem(id);
            if (invoice != null)
            {
                var pdfBytes = _pdfService.GeneratePdf(invoice);

                // Zwróć plik PDF jako odpowiedź
                return File(pdfBytes, "application/pdf", "invoice.pdf");
            }

            return BadRequest();
        }

        [Authorize]
        public async Task<IActionResult> Index(int page = 1, string searchString = "")
        {
            var invoices = await _mediator.Send(new GetAllInvoicesQuery());

            var filteredInvoices = invoices
                .Where(i => i.Number
                .Contains(searchString, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(x => x.DateCreatedUtc);

            int pageSize = 12;
            var paginatedInvoices = filteredInvoices
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var viewModel = new InvoiceViewModel
            {
                Invoices = paginatedInvoices.ToList(),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)filteredInvoices.Count() / pageSize),
                SearchString = searchString
            };

            return View(viewModel);
        }

        [Authorize]
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

            this.SetNotification("success", $"Utworzono fakturę numer: {command.Number}"); // metoda rozszerzająca do ustawiania notyfikacji

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Invoice/InvoiceItem")]
        public async Task<IActionResult> CreateInvoiceItem(CreateInvoiceItemCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("Invoice/{id}/InvoiceItem")]
        public async Task<IActionResult> GetInvoiceItem(long id)
        {
            var data = await _mediator.Send(new GetAllInvoiceItemQuery(id));

            return Ok(data);
        }

        [HttpDelete]
        [Route("Invoice/{invoiceId}/InvoiceItem/{id}")]
        public async Task<IActionResult> DeleteInvoiceItem(long invoiceId, long id)
        {
            await _mediator.Send(new RemoveInvoiceItemCommand(invoiceId, id));

            return NoContent();
        }

        [HttpDelete]
        [Route("Invoice/{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice(long invoiceId)
        {
            await _mediator.Send(new RemoveInvoiceCommand(invoiceId));

            return NoContent();
        }

        [Route("Invoice/{id}/Edit")]
        public async Task<IActionResult> Edit(long id)
        {
            var invoiceDto = await _mediator.Send(new GetByIdInvoiceQuery(id));

            if (!invoiceDto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

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
