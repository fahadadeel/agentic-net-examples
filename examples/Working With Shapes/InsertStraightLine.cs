using System;

namespace InsertLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a straight line shape to the slide
            slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

            // Save the presentation to a file
            presentation.Save("LinePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}