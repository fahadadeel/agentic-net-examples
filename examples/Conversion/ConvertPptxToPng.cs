using System;
using Aspose.Slides;

namespace ConvertPptxToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            System.String inputPath = "input.pptx";
            // Output file name pattern, {0} will be replaced by slide index
            System.String outputFormat = "slide_{0}.png";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int index = 0; index < pres.Slides.Count; index++)
            {
                // Get the current slide
                Aspose.Slides.ISlide slide = pres.Slides[index];

                // Render the slide to an image
                using (Aspose.Slides.IImage image = slide.GetImage())
                {
                    // Build the output file name
                    System.String outputPath = System.String.Format(outputFormat, index);
                    // Save the image as PNG
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }
            }

            // Save (optional) and release resources
            pres.Dispose();
        }
    }
}