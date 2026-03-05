using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input image and output presentation
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);
        string imagePath = Path.Combine(dataDir, "sample.jpg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage img;
        using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            img = pres.Images.AddImage(fs, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
        }

        // Insert a picture frame using the added image
        Aspose.Slides.IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50f, 50f,
            img.Width, img.Height,
            img);

        // Lock the aspect ratio of the picture frame
        picFrame.ShapeLock.AspectRatioLocked = true;

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}