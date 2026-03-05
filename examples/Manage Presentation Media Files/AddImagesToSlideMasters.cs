using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddImagesToSlideMasters
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths for the image to add and the output presentation
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "image.png");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide (required to access its master slide)
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

                // Retrieve the master slide associated with the first slide's layout
                Aspose.Slides.IMasterSlide masterSlide = firstSlide.LayoutSlide.MasterSlide;

                // Load the image bytes and add the image to the presentation's image collection
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                Aspose.Slides.IPPImage pictureImage = presentation.Images.AddImage(imageBytes);

                // Add the picture frame to the master slide's shapes collection
                // Parameters: shape type, X, Y, width, height, image
                masterSlide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    10,    // X position
                    10,    // Y position
                    100,   // Width
                    100,   // Height
                    pictureImage);

                // Save the presentation to disk
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}