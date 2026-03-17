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
                // Load the PPTX presentation that contains 3D effects
                Presentation presentation = new Presentation("input.pptx");

                // Create PDF options (default settings retain visual effects)
                PdfOptions pdfOptions = new PdfOptions();

                // Save the presentation as PDF
                presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

                // Ensure resources are released
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}