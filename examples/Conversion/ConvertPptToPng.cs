using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            System.String inputPath = "input.pptx";

            // Output file name pattern (e.g., slide_0.png, slide_1.png, ...)
            System.String outputPattern = "slide_{0}.png";

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (System.Int32 index = 0; index < pres.Slides.Count; index++)
                {
                    // Get the current slide
                    Aspose.Slides.ISlide slide = pres.Slides[index];

                    // Render the slide to an image
                    using (Aspose.Slides.IImage image = slide.GetImage())
                    {
                        // Build the output file name for this slide
                        System.String outputPath = System.String.Format(outputPattern, index);

                        // Save the image as PNG
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the presentation (required by authoring rules)
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}