using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source PPTX file
                string inputFile = "input.pptx";

                // Path where the PDF will be saved
                string outputFile = "output.pdf";

                // Load the presentation
                using (Presentation pres = new Presentation(inputFile))
                {
                    // Save the presentation as PDF preserving layout and formatting
                    pres.Save(outputFile, SaveFormat.Pdf);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during conversion
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}