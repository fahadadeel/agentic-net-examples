using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source PDF file
        string pdfPath = "document.pdf";
        // Path where the resulting PPTX will be saved
        string outputPath = "result.pptx";

        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Import slides from the PDF document
            pres.Slides.AddFromPdf(pdfPath);
            // Save the presentation in PPTX format
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}