using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an ellipse shape to the slide
            Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100f, 100f, 200f, 100f);

            // Set the size of the ellipse
            ellipse.Width = 300f;
            ellipse.Height = 150f;

            // Save the presentation
            presentation.Save("EllipseSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}