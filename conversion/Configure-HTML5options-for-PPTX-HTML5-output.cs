using System;
using Aspose.Slides.Export;

namespace Html5ExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source PPTX file
                string inputPath = "input.pptx";

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Configure HTML5 export options
                    Aspose.Slides.Export.Html5Options options = new Aspose.Slides.Export.Html5Options();
                    options.EmbedImages = true;                     // Embed images directly into HTML
                    options.AnimateShapes = true;                  // Enable shape animations
                    options.AnimateTransitions = true;             // Enable slide transition animations
                    options.OutputPath = "output_resources";       // Folder for external resources

                    // Set slide layout options (e.g., handout layout)
                    options.SlidesLayoutOptions = new Aspose.Slides.Export.HandoutLayoutingOptions
                    {
                        Handout = Aspose.Slides.Export.HandoutType.Handouts4Horizontal
                    };

                    // Save the presentation as HTML5
                    string outputPath = "output.html";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}