using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing.Imaging;

namespace ConvertPresentationToHtml
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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Create HTML export options
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

            // Set image scale to achieve ~150 DPI (default DPI is 96)
            float scale = 150f / 96f;
            // Use high-quality JPEG images for slides
            htmlOptions.SlideImageFormat = Aspose.Slides.Export.SlideImageFormat.Bitmap(scale, ImageFormat.Jpeg);
            // Set maximum JPEG quality
            htmlOptions.JpegQuality = 100;

            // Save the presentation as HTML with the specified options
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            pres.Dispose();
        }
    }
}