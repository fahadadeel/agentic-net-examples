using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source presentation
            string inputPath = "input.pptx";

            // Path for the generated HTML5 output
            string outputPath = "output.html";

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Configure HTML5 export options
            Html5Options options = new Html5Options();
            options.EmbedImages = true; // Embed images directly into the HTML

            // Save the presentation as HTML5, which includes speaker notes in the output
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}