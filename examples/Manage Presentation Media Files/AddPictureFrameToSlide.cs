using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define directories and file paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }
        string imagePath = Path.Combine(dataDir, "sample.jpg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Load the image from file using Aspose.Slides IImage
        Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);

        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage ppImage = presentation.Images.AddImage(image);

        // Add a picture frame using the image's original width and height
        Aspose.Slides.IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            0f,
            0f,
            (float)ppImage.Width,
            (float)ppImage.Height,
            ppImage);

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}