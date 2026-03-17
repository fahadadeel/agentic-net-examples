using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output directory for PNG images
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Load presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Define scaling factors to control image resolution (e.g., 2x for higher DPI)
                float scaleX = 2f;
                float scaleY = 2f;

                // Iterate through slides and save each as PNG
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];
                    Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY);
                    string outPath = Path.Combine(outputDir, $"slide_{i + 1}.png");
                    image.Save(outPath, Aspose.Slides.ImageFormat.Png);
                    image.Dispose();
                }

                // Save the (potentially unchanged) presentation before exiting
                pres.Save("converted.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}