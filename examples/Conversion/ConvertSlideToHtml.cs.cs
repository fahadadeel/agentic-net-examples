using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output HTML file path for the specific slide
            string outputPath = "slide1.html";
            // Index of the slide to convert (0‑based)
            int slideIndex = 0;

            // Load the source presentation
            Presentation sourcePresentation = new Presentation(inputPath);

            // Create a new presentation that will contain only the selected slide
            Presentation singleSlidePresentation = new Presentation();

            // Insert a clone of the desired slide into the new presentation
            singleSlidePresentation.Slides.InsertClone(0, sourcePresentation.Slides[slideIndex]);

            // Configure HTML export options (responsive SVG layout)
            HtmlOptions htmlOptions = new HtmlOptions();
            htmlOptions.SvgResponsiveLayout = true;

            // Save the single‑slide presentation as HTML
            singleSlidePresentation.Save(outputPath, SaveFormat.Html, htmlOptions);

            // Clean up resources
            sourcePresentation.Dispose();
            singleSlidePresentation.Dispose();
        }
    }
}