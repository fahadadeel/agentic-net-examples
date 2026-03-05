using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string sourcePath = "input.pptx";

            // Path where the responsive HTML will be saved
            string htmlPath = "output.html";

            // Load the presentation from the file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Create HTML export options (default options are sufficient for responsive HTML)
                Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions();

                // Save the presentation as responsive HTML
                presentation.Save(htmlPath, Aspose.Slides.Export.SaveFormat.Html, options);
            }

            // Indicate completion
            Console.WriteLine("Presentation has been converted to responsive HTML.");
        }
    }
}