using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Render3DToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputDirectory = "output";

                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                using (Presentation pres = new Presentation(inputPath))
                {
                    // High‑resolution scaling factors
                    float scaleX = 3f;
                    float scaleY = 3f;

                    for (int index = 0; index < pres.Slides.Count; index++)
                    {
                        ISlide slide = pres.Slides[index];
                        IImage image = slide.GetImage(scaleX, scaleY);
                        string outputPath = Path.Combine(outputDirectory, $"slide_{index + 1}.png");
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                        image.Dispose();
                    }

                    // Save the (unchanged) presentation before exiting
                    pres.Save("output_pres.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}