using System;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output HTML file path
            string outputPath = "output.html";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create HTML export options
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

            // Set slide image format to high-quality bitmap with 150 DPI (PNG format)
            htmlOptions.SlideImageFormat = Aspose.Slides.Export.SlideImageFormat.Bitmap(150f, ImageFormat.Png);

            // Save the presentation as HTML with the specified options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}