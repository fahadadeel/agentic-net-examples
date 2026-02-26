using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation file
            string inputPath = "input.pptx";

            // Path to the output HTML file
            string outputPath = "output.html";

            // Load the presentation from the file
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Optional: configure HTML export options (e.g., embed images)
                HtmlOptions htmlOptions = new HtmlOptions();
                // htmlOptions.SlidesLayoutOptions can be set here if needed

                // Save the presentation as HTML
                presentation.Save(outputPath, SaveFormat.Html, htmlOptions);
            }

            // Indicate completion
            Console.WriteLine("Presentation has been converted to HTML successfully.");
        }
    }
}