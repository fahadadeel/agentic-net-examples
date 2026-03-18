using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Load the existing presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Export the presentation as PPTX
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}