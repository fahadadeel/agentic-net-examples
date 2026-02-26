using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPresentationToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation (contains math equations)
            string inputPath = "input.pptx";

            // Folder where PNG images and the saved presentation will be stored
            string outputFolder = "output";

            // Ensure the output directory exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Convert each slide to a PNG image
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                ISlide slide = presentation.Slides[index];
                using (IImage slideImage = slide.GetImage())
                {
                    string imagePath = Path.Combine(outputFolder, $"slide_{index}.png");
                    slideImage.Save(imagePath, ImageFormat.Png);
                }
            }

            // Save the presentation before exiting (as required)
            string savedPresentationPath = Path.Combine(outputFolder, "converted.pptx");
            presentation.Save(savedPresentationPath, SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}