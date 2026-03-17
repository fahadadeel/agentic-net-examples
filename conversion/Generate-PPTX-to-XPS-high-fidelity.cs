using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source PPTX file
            var inputPath = "input.pptx";
            // Path where the XPS file will be saved
            var outputPath = "output.xps";

            // Load the presentation from the PPTX file
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Create XPS export options
                var options = new XpsOptions();
                // Example option: convert metafiles to PNG for better compatibility
                options.SaveMetafilesAsPng = true;

                // Save the presentation as XPS using the specified options
                presentation.Save(outputPath, SaveFormat.Xps, options);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}