using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the image file on disk
        string imagePath = "image1.jpg";

        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Open the image file as a stream
            using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                // Add the image to the presentation using KeepLocked behavior
                Aspose.Slides.IPPImage img = pres.Images.AddImage(fileStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                // Insert the image onto the first slide as a picture frame
                pres.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
            }

            // Save the presentation to a PPTX file
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}