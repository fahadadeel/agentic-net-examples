using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);
        shape.AddTextFrame("Click here to view Aspose.Slides documentation");

        // Set an external hyperlink on the shape's text portion
        Aspose.Slides.IHyperlinkManager hyperlinkManager = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
        hyperlinkManager.SetExternalHyperlinkClick("https://docs.aspose.com/slides/net/");

        // Save the presentation before exiting
        presentation.Save("PresentationWithLink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}