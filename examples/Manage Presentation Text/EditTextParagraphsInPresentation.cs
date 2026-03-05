using System;

public class Program
{
    public static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 100);

        // Set the text of the shape
        autoShape.TextFrame.Text = "First paragraph";

        // Get the first paragraph
        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

        // Align the paragraph to center
        paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

        // Add a second paragraph
        Aspose.Slides.IParagraph secondParagraph = new Aspose.Slides.Paragraph();
        secondParagraph.Text = "Second paragraph aligned right";
        secondParagraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Right;
        autoShape.TextFrame.Paragraphs.Add(secondParagraph);

        // Save the presentation
        presentation.Save("ManagedParagraphs_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}