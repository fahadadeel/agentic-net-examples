using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation instance
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide in the presentation
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Save the presentation to a PPTX file
        presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}