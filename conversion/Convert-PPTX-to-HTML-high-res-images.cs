using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToHtmlHighRes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputDir = "output";
            string outputHtml = Path.Combine(outputDir, "presentation.html");

            try
            {
                // Ensure output directory exists
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure HTML export options with high‑resolution images
                HtmlOptions htmlOptions = new HtmlOptions
                {
                    // Use a custom formatter (optional, e.g., for embedding fonts)
                    HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new EmbedAllFontsHtmlController()),
                    // Set slide image format to high‑resolution JPEG (300 DPI)
                    SlideImageFormat = SlideImageFormat.Bitmap(300f, Aspose.Slides.ImageFormat.Jpeg)
                };

                // Save presentation as HTML
                presentation.Save(outputHtml, SaveFormat.Html, htmlOptions);

                // Dispose presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during conversion: " + ex.Message);
            }
        }
    }
}