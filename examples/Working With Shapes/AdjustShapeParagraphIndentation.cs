using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 200);

        // Add a text frame with two lines
        var textFrame = shape.TextFrame;
        textFrame.Text = "First line\nSecond line";

        // Access the first paragraph of the text frame
        var paragraph = textFrame.Paragraphs[0];

        // Set a custom first line indent (in points)
        paragraph.ParagraphFormat.Indent = 20f;

        // Apply default paragraph indents shifts based on bullet settings
        paragraph.ParagraphFormat.Bullet.ApplyDefaultParagraphIndentsShifts();

        // Save the presentation to a file
        presentation.Save("ParagraphIndentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}