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
                // Input PowerPoint file path
                string inputPath = "input.pptx";
                // Output PDF file path
                string outputPath = "output.pdf";

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Save the presentation as PDF
                    presentation.Save(outputPath, SaveFormat.Pdf);
                }

                Console.WriteLine("Presentation successfully converted to PDF.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during conversion
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}