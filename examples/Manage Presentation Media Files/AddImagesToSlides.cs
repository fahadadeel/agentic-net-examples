using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Path to the local image file
        string inputImagePath = "image1.png";
        // Path where the PPTX will be saved
        string outputPath = "output.pptx";

        // Read the image bytes from the file system
        byte[] imageData = File.ReadAllBytes(inputImagePath);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

        // Get the first slide; if none exists, add a blank slide
        Aspose.Slides.ISlide slide;
        if (pres.Slides.Count > 0)
        {
            slide = pres.Slides[0];
        }
        else
        {
            slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank));
        }

        // Insert a picture frame that covers the entire slide
        slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            0,
            0,
            pres.SlideSize.Size.Width,
            pres.SlideSize.Size.Height,
            img);

        // Save the presentation to the specified file
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}