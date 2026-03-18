using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string inputPath = "input.pptx";
            // Path where the modified presentation will be saved
            string outputPath = "output.pptx";

            try
            {
                // Load the existing presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // TODO: Add manipulation code here

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during loading or saving
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}