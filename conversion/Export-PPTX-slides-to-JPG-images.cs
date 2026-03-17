using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToJpgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input presentation path
                string inputPath = "input.pptx";

                // Output directory for JPG images
                string outputDir = "output_images";
                Directory.CreateDirectory(outputDir);

                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through each slide
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];

                        // Generate image with original scale (1f, 1f)
                        using (IImage image = slide.GetImage(1f, 1f))
                        {
                            string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.jpg");
                            image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                        }
                    }

                    // Save the presentation before exiting (optional)
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}