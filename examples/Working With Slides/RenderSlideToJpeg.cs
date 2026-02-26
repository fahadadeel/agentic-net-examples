using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Slides;

namespace SlideToJpegExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string sourcePath = "input.pptx";
            // Directory to save JPEG images
            string outputDir = "output";

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Iterate through all slides
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[index];
                    // Render the slide to an image (full scale)
                    using (Aspose.Slides.IImage image = slide.GetImage(1f, 1f))
                    {
                        string imagePath = Path.Combine(outputDir, $"Slide_{index + 1}.jpg");
                        // Save the image as JPEG
                        image.Save(imagePath, ImageFormat.Jpeg);
                    }
                }

                // Save the presentation before exiting (even if unchanged)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}