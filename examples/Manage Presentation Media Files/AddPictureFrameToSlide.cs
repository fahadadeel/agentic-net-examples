using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load image file into presentation images collection
        string imagePath = "sample.jpg";
        byte[] imageBytes = File.ReadAllBytes(imagePath);
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageBytes);

        // Add picture frame to slide
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50f, 50f, 300f, 200f,
            image);

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}