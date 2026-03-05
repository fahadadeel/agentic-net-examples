using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the image file
        string imagePath = "image.png";

        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Add the image to the presentation's image collection
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(File.ReadAllBytes(imagePath));

            // Get the first master slide
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Add a picture frame to the master slide
            masterSlide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 10, 10, 100, 100, image);

            // Save the presentation
            presentation.Save("MasterWithImage.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}