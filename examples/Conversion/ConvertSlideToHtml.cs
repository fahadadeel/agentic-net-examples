using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertSlideToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            string inputPath = "input.pptx";
            // Output HTML file for the specific slide
            string outputPath = "slide1.html";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Specify the slide index (1‑based) to convert
            int[] slideIndices = new int[] { 1 };

            // Save the specified slide as HTML
            presentation.Save(outputPath, slideIndices, Aspose.Slides.Export.SaveFormat.Html);

            // Release resources
            presentation.Dispose();
        }
    }
}