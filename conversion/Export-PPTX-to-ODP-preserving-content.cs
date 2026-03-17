using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToOdp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.odp";

            try
            {
                // Load the PPTX presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Save the presentation in ODP format
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during conversion
                Console.WriteLine("Conversion failed: " + ex.Message);
            }
        }
    }
}