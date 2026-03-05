using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Load image from file and add to presentation resources
        using (FileStream imageStream = new FileStream("image.jpg", FileMode.Open, FileAccess.Read))
        {
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
            // Add a picture frame to the first slide using the loaded image
            Aspose.Slides.IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                50f, 50f, 300f, 200f,
                image);
        }

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}