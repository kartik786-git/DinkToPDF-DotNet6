using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDinkToPDF.Services;

namespace WebApplicationDinkToPDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        private readonly PdfGenerator _pdfGenerator;

        public PDFController(PdfGenerator pdfGenerator)
        {
            this._pdfGenerator = pdfGenerator;
        }

        [HttpPost]
        public IActionResult GeneratePdf()
        {
            string htmlContent = "<html><body><h1>Hello, World!</h1>" +
                "<img src='https://cdn.pixabay.com/photo/2014/02/27/16/10/flowers-276014_1280.jpg' " +
                "alt='Example Image'></body></html>";


            byte[] pdfBytes = _pdfGenerator.GeneratorPdf(htmlContent);

            return File(pdfBytes, "application/pdf", "generated.pdf");
        }
    }

}
