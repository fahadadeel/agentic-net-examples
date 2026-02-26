using System;

namespace ConvertSlideToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            System.String inputPath = "input.pptx";
            // Format string for output PNG files
            System.String outputFormat = "slide_{0}.png";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Convert each slide to a PNG image
            for (int index = 0; index < pres.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[index];
                using (Aspose.Slides.IImage image = slide.GetImage())
                {
                    System.String outputPath = System.String.Format(outputFormat, index);
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }
            }

            // Save the presentation before exiting (no modifications made)
            pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}