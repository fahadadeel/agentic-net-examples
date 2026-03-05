using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

        // Cast the shape to AutoShape
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add an empty text frame
        autoShape.AddTextFrame("");

        // Access the text frame
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Get the first paragraph and portion
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];

        // Set the display text
        portion.Text = "Aspose.Slides";

        // Set an external hyperlink on click
        Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
        hyperlinkManager.SetExternalHyperlinkClick("http://www.aspose.com");

        // Save the updated presentation
        presentation.Save("HyperlinkPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}