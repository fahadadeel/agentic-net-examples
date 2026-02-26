using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);

        // Add a TextFrame with initial text
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("Initial text");

        // Create a new paragraph
        Aspose.Slides.IParagraph newParagraph = new Aspose.Slides.Paragraph();

        // Create a portion with the desired text
        Aspose.Slides.IPortion newPortion = new Aspose.Slides.Portion("This is a new paragraph.");

        // Add the portion to the paragraph
        newParagraph.Portions.Add(newPortion);

        // Add the new paragraph to the TextFrame
        textFrame.Paragraphs.Add(newParagraph);

        // Save the presentation
        presentation.Save("AddParagraph_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}