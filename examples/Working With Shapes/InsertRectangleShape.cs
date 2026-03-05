using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace MyPresentationApp
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

                // Add a rectangle shape
                Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 300, 150);

                // Set fill color to solid blue
                rectangle.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                rectangle.FillFormat.SolidFillColor.Color = Color.Blue;

                // Set line color to black and width
                rectangle.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                rectangle.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
                rectangle.LineFormat.Width = 2;

                // Save the presentation
                presentation.Save("RectanglePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}