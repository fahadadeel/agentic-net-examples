using System;
using Aspose.Slides;

namespace ExportThumbnailToJpeg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define scaling factors (full size)
            int scaleX = 1;
            int scaleY = scaleX;

            // Path to the input presentation
            System.String inputPath = "input.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Export each slide as a JPEG thumbnail
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                using (Aspose.Slides.IImage thumbnail = slide.GetImage(scaleX, scaleY))
                {
                    System.String imageFileName = System.String.Format("Slide_{0}.jpg", slide.SlideNumber);
                    thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}