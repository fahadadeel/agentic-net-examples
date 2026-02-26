using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first (empty) slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to host the text
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 500, 300);

            // Add an empty text frame to the shape
            Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame("");

            // HTML content to import
            string html = "<p>This is <b>bold</b> and <i>italic</i> text.</p>"
                        + "<ul><li>Item 1</li><li>Item 2</li></ul>";

            // Import HTML into the paragraph collection of the text frame
            Aspose.Slides.IParagraphCollection paragraphs = textFrame.Paragraphs;
            paragraphs.AddFromHtml(html);

            // Save the presentation
            presentation.Save("HtmlImportedPresentation.pptx",
                Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}