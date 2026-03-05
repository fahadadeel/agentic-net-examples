using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

        // Add a text frame to the shape
        autoShape.AddTextFrame("Sample text");

        // Set the autofit type for the text frame
        Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
        textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

        // Save the presentation
        presentation.Save("AutofitShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}