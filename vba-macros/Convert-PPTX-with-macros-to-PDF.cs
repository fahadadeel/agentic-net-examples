using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the PPTX presentation that contains macros
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptm");

                // Configure PDF options to include OLE data (e.g., embedded macro content)
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.IncludeOleData = true;

                // Save the presentation as a PDF file
                presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}