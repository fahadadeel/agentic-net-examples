using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load an image from file and add it to the presentation's image collection
        FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read);
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
        imageStream.Close();

        // Add a picture frame shape to the slide
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50f, 50f, 200f, 200f,
            image);

        // Set the picture fill mode to Tile
        pictureFrame.PictureFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;

        // Save the presentation in PPTX format
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}