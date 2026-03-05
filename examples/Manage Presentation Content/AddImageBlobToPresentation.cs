using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the image file to be added as a BLOB
        string imagePath = "large_image.jpg";
        // Path where the resulting presentation will be saved
        string outputPath = "presentationWithLargeImage.pptx";

        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Open the image file as a stream
            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                // Add the image to the presentation with KeepLocked behavior
                Aspose.Slides.IPPImage img = pres.Images.AddImage(fs, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                // Insert the image into the first slide as a picture frame
                pres.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
            }

            // Save the presentation in PPTX format
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}