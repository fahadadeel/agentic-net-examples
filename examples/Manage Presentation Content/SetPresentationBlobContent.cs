using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BlobPresentationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the large image to be added as a BLOB
            string imagePath = "large_image.jpg";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Open the image file as a stream
                using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    // Add the image to the presentation with KeepLocked behavior
                    IPPImage img = pres.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                    // Insert the image onto the first slide as a picture frame
                    pres.Slides[0].Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        0,
                        0,
                        300,
                        200,
                        img);
                }

                // Save the presentation in PPT format
                pres.Save("BlobPresentation.ppt", SaveFormat.Ppt);
            }
        }
    }
}