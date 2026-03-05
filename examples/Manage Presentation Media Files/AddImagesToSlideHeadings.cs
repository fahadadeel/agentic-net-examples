using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ImageHeadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the image file to be added
            string imagePath = "image.jpg";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add the image to the presentation and place it on the slide
            using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 150, 300, 200, image);
            }

            // Add a heading shape (rectangle) to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 50);
            Aspose.Slides.IAutoShape headingShape = (Aspose.Slides.IAutoShape)shape;
            headingShape.AddTextFrame("Presentation Heading");

            // Save the presentation to a PPTX file
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}