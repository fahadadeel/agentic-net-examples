using System;

namespace SlideToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            string inputPath = "input.pptx";
            // Output HTML file
            string outputPath = "output.html";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Create HTML export options (optional)
                Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

                // Save the presentation as HTML
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
            }
        }
    }
}