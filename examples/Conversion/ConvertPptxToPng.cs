using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            System.String inputPath = "input.pptx";

            // Output file name pattern (e.g., slide_0.png, slide_1.png, ...)
            System.String outputFormat = "slide_{0}.png";

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through each slide and export it as PNG
                for (int index = 0; index < pres.Slides.Count; index++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[index];
                    using (Aspose.Slides.IImage image = slide.GetImage())
                    {
                        System.String outputPath = System.String.Format(outputFormat, index);
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the presentation (required by authoring rules)
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}