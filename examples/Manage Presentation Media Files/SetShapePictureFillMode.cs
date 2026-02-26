using System;
using Aspose.Slides;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Load an image from file
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile("sample_image.jpg");

            // Add the image to the presentation's image collection and obtain an IPPImage
            Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

            // Add a rectangle auto shape to the slide
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50f,   // X position
                50f,   // Y position
                400f,  // Width
                300f   // Height
            );

            // Set the shape's fill type to picture
            shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;

            // Get the picture fill format of the shape
            Aspose.Slides.IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;

            // Assign the image to the picture fill
            picFill.Picture.Image = ppImg;

            // Set the picture fill mode (e.g., Tile)
            picFill.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;

            // Save the presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}