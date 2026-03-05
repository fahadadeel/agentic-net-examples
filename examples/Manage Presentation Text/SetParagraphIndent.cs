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

        // Add a rectangle autoshape
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 100);

        // Add a text frame to the shape
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("This is a paragraph with custom indent.");

        // Get the first paragraph
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

        // Set the first line indent (in points)
        paragraph.ParagraphFormat.Indent = 30f;

        // Save the presentation
        presentation.Save("ParagraphIndent_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}