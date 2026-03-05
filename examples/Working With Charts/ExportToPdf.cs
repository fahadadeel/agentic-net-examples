using System;

namespace AsposeSlidesPdfExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing PowerPoint presentation
            using (var presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Create PDF export options (optional customization can be added here)
                var pdfOptions = new Aspose.Slides.Export.PdfOptions();

                // Export the presentation to PDF format
                presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
    }
}