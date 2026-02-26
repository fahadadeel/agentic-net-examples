using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main()
    {
        // Define data directory and file paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string imagePath = Path.Combine(dataDir, "image.jpg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Ensure the data directory exists
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

        // Set the shape's fill type to picture
        shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;

        // Load an image from file
        Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);

        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

        // Apply the image to the shape's fill
        shape.FillFormat.PictureFillFormat.Picture.Image = ppImg;

        // Optionally set the picture fill mode
        shape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;

        // Save the presentation in PPTX format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}