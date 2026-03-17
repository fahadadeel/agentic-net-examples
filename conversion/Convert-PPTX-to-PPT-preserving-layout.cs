using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for source PPTX and target PPT files
            var sourcePath = "input.pptx";
            var targetPath = "output.ppt";

            try
            {
                // Load the PPTX presentation
                using (var presentation = new Aspose.Slides.Presentation(sourcePath))
                {
                    // Save the presentation in PPT format
                    presentation.Save(targetPath, Aspose.Slides.Export.SaveFormat.Ppt);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during loading or saving
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}