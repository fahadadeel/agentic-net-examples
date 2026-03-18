using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyPresentationApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                var presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                var slide = presentation.Slides[0];

                // Logical constant value
                const int ImportantValue = 42;

                // Conditional content handling based on the constant
                if (ImportantValue > 10)
                {
                    // Add a rectangle shape with a text frame displaying the constant
                    var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                    shape.AddTextFrame($"Important value is {ImportantValue}");
                }

                // Save the presentation before exiting
                presentation.Save("ConditionalContent.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}