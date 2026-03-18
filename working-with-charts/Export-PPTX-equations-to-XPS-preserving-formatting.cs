using System;
using Aspose.Slides.Export;

namespace ExportEquationsToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";
            // Path for the resulting XPS document
            string outputPath = "output.xps";

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure XPS export options (e.g., preserve metafiles as PNG)
                XpsOptions options = new XpsOptions();
                options.SaveMetafilesAsPng = true;
                options.ShowHiddenSlides = true; // include hidden slides if any

                // Save the presentation as XPS with the specified options
                presentation.Save(outputPath, SaveFormat.Xps, options);

                // Dispose the presentation object
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}