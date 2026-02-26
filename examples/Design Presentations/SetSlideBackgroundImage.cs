using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Set the slide background to use an image
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            slide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

            // Load image from file and add it to the presentation's image collection
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "background.jpg");
            Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage imageInPresentation = presentation.Images.AddImage(image);

            // Assign the image to the slide background
            slide.Background.FillFormat.PictureFillFormat.Picture.Image = imageInPresentation;

            // Save the presentation
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SlideWithImageBackground.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}