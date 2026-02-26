using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ApplyFillColorToRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100,   // X position
                100,   // Y position
                300,   // Width
                200);  // Height

            // Apply solid fill color to the rectangle
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.Chocolate;

            // Optionally, set a solid line around the rectangle
            shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
            shape.LineFormat.Width = 2.0;

            // Save the presentation
            presentation.Save("RectangleFill.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}