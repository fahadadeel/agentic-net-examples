using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPT/PPTX file
            System.String inputPath = "input.pptx";

            // Output file name pattern for each slide image
            System.String outputFormat = "slide_{0}.png";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides and export each as PNG
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
            pres.Save("output_saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}