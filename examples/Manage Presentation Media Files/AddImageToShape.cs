using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Load an image from file (replace with a valid path)
        string imagePath = "sample.jpg";
        Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
        Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, // shape type
            50,    // X position
            50,    // Y position
            400,   // width
            300);  // height

        // Set the shape's fill type to picture
        shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;

        // Get the picture fill format and assign the image
        Aspose.Slides.IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
        picFill.Picture.Image = ppImg;

        // Optionally set the fill mode (e.g., stretch to fill the shape)
        picFill.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

        // Save the presentation as PPTX
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}