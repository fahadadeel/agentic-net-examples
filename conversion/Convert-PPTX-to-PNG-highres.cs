using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToPngHighRes
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Input PowerPoint file
                string inputPath = "input.pptx";

                // Output directory for PNG images
                string outputDir = "output";
                Directory.CreateDirectory(outputDir);

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // High‑quality scaling factor (2x)
                    float scaleX = 2f;
                    float scaleY = 2f;

                    // Iterate through all slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        // Render slide to image with high resolution
                        Aspose.Slides.IImage slideImage = presentation.Slides[i].GetImage(scaleX, scaleY);

                        // Build output file name
                        string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.png");

                        // Save image as PNG using fully‑qualified ImageFormat
                        slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);

                        // Release image resources
                        slideImage.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                // Output any errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}