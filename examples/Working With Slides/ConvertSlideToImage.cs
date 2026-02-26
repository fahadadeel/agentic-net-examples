using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertSlideToImage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            System.String inputPath = "input.pptx";

            // Output image file name format
            System.String outputFormat = "Slide_{0}.jpg";

            // Scale factors for the thumbnail image
            int scaleX = 1;
            int scaleY = scaleX;

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Convert each slide to an image
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                using (Aspose.Slides.IImage thumbnail = slide.GetImage(scaleX, scaleY))
                {
                    System.String imageFileName = System.String.Format(outputFormat, slide.SlideNumber);
                    thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}