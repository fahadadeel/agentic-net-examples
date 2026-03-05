using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string sourcePath = "input.pptx";
        // Directory to save slide images
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        // Load the presentation
        Presentation presentation = new Presentation(sourcePath);

        // Iterate through slides and save each as PNG
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            ISlide slide = presentation.Slides[i];
            IImage image = slide.GetImage();
            string imagePath = Path.Combine(outputDir, $"slide_{i + 1}.png");
            image.Save(imagePath, ImageFormat.Png);
            image.Dispose();
        }

        // Save the presentation before exiting
        presentation.Save(sourcePath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}