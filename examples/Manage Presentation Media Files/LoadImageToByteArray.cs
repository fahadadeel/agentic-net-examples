using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the image file
        string imagePath = "image.png";

        // Load the image file into a byte array
        byte[] imageBytes = File.ReadAllBytes(imagePath);

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add the image to the presentation from the byte array
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageBytes);

        // Insert the image onto the first slide
        presentation.Slides[0].Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            0, 0, 300, 200,
            image);

        // Save the presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}