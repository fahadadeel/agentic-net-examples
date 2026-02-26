using System;
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

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Add a text frame with sample text
        shape.AddTextFrame("Sample text that may overflow the shape if autofit is enabled.");

        // Disable autofit
        shape.TextFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.None;

        // Save the presentation
        presentation.Save("DisableAutofit_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}