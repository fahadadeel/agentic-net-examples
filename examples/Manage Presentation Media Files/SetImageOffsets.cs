using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ImageOffsetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Load an image from file into the presentation's image collection
                using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
                {
                    Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

                    // Add a picture frame shape to the slide
                    Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        50f,   // X position
                        50f,   // Y position
                        300f,  // Width
                        200f,  // Height
                        image);

                    // Access the picture fill format of the shape
                    Aspose.Slides.IPictureFillFormat pictureFillFormat = pictureFrame.FillFormat.PictureFillFormat;

                    // Set the fill mode to Tile so offsets take effect
                    pictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;

                    // Specify horizontal and vertical offsets (in points) from the shape's origin
                    pictureFillFormat.TileOffsetX = 20f;   // Move texture 20 points to the right
                    pictureFillFormat.TileOffsetY = -10f; // Move texture 10 points up

                    // Optionally, set stretch offsets (percentage of the shape's bounding box)
                    pictureFillFormat.StretchOffsetLeft = 5f; // Inset 5% from the left edge
                    pictureFillFormat.StretchOffsetTop = 5f;  // Inset 5% from the top edge
                }

                // Save the presentation to a file
                presentation.Save("ImageOffsetResult.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}