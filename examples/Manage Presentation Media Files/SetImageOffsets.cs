using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a picture frame shape to the slide
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle, // shape type
            50f,                               // X position (points)
            50f,                               // Y position (points)
            300f,                              // Width (points)
            200f,                              // Height (points)
            presentation.Images.AddImage(File.ReadAllBytes("sample.jpg")) // image
        );

        // Get the picture fill format of the shape
        Aspose.Slides.IPictureFillFormat pictureFillFormat = pictureFrame.FillFormat.PictureFillFormat;

        // Set the fill mode to Tile
        pictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;

        // Specify the horizontal offset from the left edge of the shape's bounding box (percentage)
        pictureFillFormat.StretchOffsetLeft = 10f; // 10% inset from the left edge

        // Save the presentation
        presentation.Save("ImageOffsetExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}