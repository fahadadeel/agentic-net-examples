using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pdf";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Create PDF options (default settings)
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the presentation as PDF
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}