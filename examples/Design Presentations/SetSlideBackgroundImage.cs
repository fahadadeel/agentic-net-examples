using System;
using System.IO;
using Aspose.Slides;

namespace SetSlideBackgroundImage
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

            // Load the image from file
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "background.jpg");
            Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage imageX = presentation.Images.AddImage(image);

            // Assign the image to the slide background
            slide.Background.FillFormat.PictureFillFormat.Picture.Image = imageX;

            // Save the presentation
            presentation.Save("ImageBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}