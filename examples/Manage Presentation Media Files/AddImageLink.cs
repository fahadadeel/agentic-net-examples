using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the image file to be added
            string imagePath = "image.png";

            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage image = pres.Images.AddImage(File.ReadAllBytes(imagePath));

                // Add a picture frame on the first slide using the added image
                Aspose.Slides.IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    10, 10, 100, 100,
                    image);

                // Assign an external hyperlink to the picture
                pictureFrame.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.example.com/");
                pictureFrame.HyperlinkClick.Tooltip = "Open example.com";

                // Save the presentation
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}