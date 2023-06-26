using IntuitivePaper.Domain.Interfaces;
using iText.Html2pdf;
using Microsoft.AspNetCore.Hosting;
using RazorEngine;
using RazorEngine.Templating;

namespace IntuitivePaper.Application.Services
{
    public class PdfService : IPdfService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PdfService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public byte[] GeneratePdf(Domain.Entities.Invoice invoice)
        {
            // Pobierz treść faktury
            var htmlContent = GetInvoiceContent(invoice);

            // Konwertuj HTML na PDF
            using (MemoryStream memoryStream = new MemoryStream())
            {
                HtmlConverter.ConvertToPdf(htmlContent, memoryStream);
                byte[] pdfBytes = memoryStream.ToArray();
                return pdfBytes;
            }

        }
        private string GetInvoiceContent(Domain.Entities.Invoice invoice)
        {
            // Dodaj treść faktury, korzystając z Razor View Engine
            string viewName = "InvoicePdf";
            string viewPath = GetViewAbsolutePath($"Views/Invoice/{viewName}.cshtml");
            string htmlContent = RenderViewToString(viewPath, invoice);

            return htmlContent;
        }

        private string RenderViewToString(string viewPath, object model)
        {
            // Wczytaj zawartość widoku z pliku
            string viewContent = System.IO.File.ReadAllText(viewPath);

            // Renderuj widok przy użyciu RazorEngine
            string result = Engine.Razor.RunCompile(viewContent, viewPath, null, model);

            return result;
        }

        private string GetViewAbsolutePath(string relativePath)
        {
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string viewAbsolutePath = Path.Combine(contentRootPath, relativePath);
            return viewAbsolutePath;
        }
    }
}