using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape that will contain the text
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Add an empty text frame to the shape
        shape.AddTextFrame(string.Empty);
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

        // Create a new paragraph using ParagraphFactory
        Aspose.Slides.ParagraphFactory paragraphFactory = new Aspose.Slides.ParagraphFactory();
        Aspose.Slides.IParagraph paragraph = paragraphFactory.CreateParagraph();

        // Set the paragraph text
        paragraph.Text = "This is a formatted paragraph.";

        // Apply formatting: center alignment
        paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

        // Add the paragraph to the text frame
        textFrame.Paragraphs.Add(paragraph);

        // Save the presentation
        presentation.Save("ParagraphDemo_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}