using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file
        string inputPath = "input.pptx";

        // Directory to store PNG images
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        // Load presentation
        Presentation presentation = new Presentation(inputPath);

        // High-quality scaling factors
        float scaleX = 2f;
        float scaleY = 2f;

        // Convert each slide to PNG
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            ISlide slide = presentation.Slides[i];
            IImage image = slide.GetImage(scaleX, scaleY);
            string outputPath = Path.Combine(outputDir, "slide_" + i + ".png");
            image.Save(outputPath, ImageFormat.Png);
            image.Dispose();
        }

        // Save the presentation before exiting (optional output file)
        presentation.Save("output.pptx", SaveFormat.Pptx);
        presentation.Dispose();
    }
}