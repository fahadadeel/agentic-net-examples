using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractPptxToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PPTX file path
                string inputPath = "input.pptx";

                // Output directory for PNG images
                string outputDir = "output";
                Directory.CreateDirectory(outputDir);

                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int index = 0; index < pres.Slides.Count; index++)
                    {
                        // Get the current slide
                        Aspose.Slides.ISlide slide = pres.Slides[index];

                        // Render the slide to an image (default size)
                        Aspose.Slides.IImage slideImage = slide.GetImage();

                        // Build the output file name
                        string outputPath = Path.Combine(outputDir, $"slide_{index + 1}.png");

                        // Save the image as PNG
                        slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the presentation before exiting (as per lifecycle rule)
                    pres.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Simple error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}