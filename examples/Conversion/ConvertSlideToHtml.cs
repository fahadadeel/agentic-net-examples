using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToHtmlConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string sourcePath = "input.pptx";

            // Path to the output HTML file for the specific slide
            string outputPath = "slide1.html";

            // Slide numbers are 1‑based; here we convert only the first slide
            int[] slideIndices = new int[] { 1 };

            // Load the presentation
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Create HTML export options (optional customizations can be added)
                HtmlOptions htmlOptions = new HtmlOptions();

                // Save only the specified slide as HTML
                presentation.Save(outputPath, slideIndices, SaveFormat.Html, htmlOptions);
            }
        }
    }
}