using System;

namespace AddRectangleShape
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

                // Add a rectangle auto shape to the slide
                Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    50f,   // X position
                    50f,   // Y position
                    200f,  // Width
                    100f   // Height
                );

                // Save the presentation to a PPTX file
                presentation.Save("RectangleShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}