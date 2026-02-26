using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Path to the image file to be added
        string imagePath = "large_image.jpg";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Open the image file stream and add the image to the presentation with KeepLocked behavior
        using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            Aspose.Slides.IPPImage img = pres.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

            // Add a picture frame containing the image to the first slide
            Aspose.Slides.IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        }

        // Save the presentation to a file
        pres.Save("presentationWithLargeImage.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        pres.Dispose();
    }
}