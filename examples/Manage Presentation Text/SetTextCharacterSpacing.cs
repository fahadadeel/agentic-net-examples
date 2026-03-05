using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with a text frame
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        shape.AddTextFrame("Sample text for character spacing.");

        // Access the first paragraph and its first portion
        Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];

        // Set character spacing (e.g., 2 points)
        portion.PortionFormat.Spacing = 2f;

        // Save the presentation
        presentation.Save("CharacterSpacing_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}