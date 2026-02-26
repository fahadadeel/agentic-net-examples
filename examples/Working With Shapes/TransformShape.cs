using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace WorkingWithShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation (replace with your file path)
            string inputPath = "input.pptx";
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide and its shape collection
            Aspose.Slides.ISlide srcSlide = pres.Slides[0];
            Aspose.Slides.IShapeCollection srcShapes = srcSlide.Shapes;

            // Assume there is at least one shape on the slide
            Aspose.Slides.IShape shape = srcShapes[0];

            // Move the shape
            shape.X = shape.X + 100f; // shift right by 100 points
            shape.Y = shape.Y + 50f;  // shift down by 50 points

            // Scale the shape (increase size by 150%)
            shape.Width = shape.Width * 1.5f;
            shape.Height = shape.Height * 1.5f;

            // Rotate the shape 45 degrees clockwise
            shape.Rotation = 45f;

            // Clone the transformed shape onto a new blank slide
            Aspose.Slides.ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            Aspose.Slides.ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout);
            Aspose.Slides.IShapeCollection destShapes = destSlide.Shapes;

            // Add clone at a new position (offset by 200 points)
            destShapes.AddClone(shape, shape.X + 200f, shape.Y + 200f);

            // Save the modified presentation
            string outputPath = "output.pptx";
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
    }
}