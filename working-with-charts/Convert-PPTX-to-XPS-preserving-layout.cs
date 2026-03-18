using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation and output XPS file
            string inputPath = "input.pptx";
            string outputPath = "output.xps";

            try
            {
                // Load the presentation from file
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Create XPS export options
                    XpsOptions options = new XpsOptions();
                    // Convert metafiles to PNG to ensure proper rendering
                    options.SaveMetafilesAsPng = true;

                    // Save the presentation as XPS using the specified options
                    pres.Save(outputPath, SaveFormat.Xps, options);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during conversion
                Console.WriteLine("Error during conversion: " + ex.Message);
            }
        }
    }
}