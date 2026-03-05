using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceImageWithExisting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Get the first shape and cast it to IPictureFrame
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes[0] as Aspose.Slides.IPictureFrame;

            if (pictureFrame != null)
            {
                // Get an existing image from the presentation's image collection (e.g., the first image)
                Aspose.Slides.IPPImage existingImage = pres.Images[0];

                // Replace the picture frame's image with the existing image
                pictureFrame.PictureFormat.Picture.Image = existingImage;
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}