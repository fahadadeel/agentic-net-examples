using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation containing embedded mathematical equations
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Configure PDF export options to preserve equation fidelity
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.EmbedFullFonts = true; // Embed all fonts for accurate rendering
            pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.Pdf15; // Set PDF compliance level

            // Save the presentation as PDF
            presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}