using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PictureFrameDemo
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

                // Load an image from file
                using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
                {
                    // Add the image to the presentation's image collection
                    Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

                    // Add a picture frame to the slide using the loaded image
                    Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                        ShapeType.Rectangle,   // Shape type
                        100,                   // X position (points)
                        100,                   // Y position (points)
                        300,                   // Width (points)
                        200,                   // Height (points)
                        image);                // Image to display

                    // Set picture frame properties
                    pictureFrame.Width = 400;               // New width
                    pictureFrame.Height = 300;              // New height
                    pictureFrame.Rotation = 45;             // Rotate 45 degrees
                    pictureFrame.AlternativeText = "Demo picture frame";

                    // Example of setting the picture fill format (optional)
                    pictureFrame.PictureFormat.Picture.Image = image;
                }

                // Save the presentation to disk
                presentation.Save("PictureFrameDemo_out.pptx", SaveFormat.Pptx);
            }
        }
    }
}