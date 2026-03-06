using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

        // Add a second empty slide using the first layout slide
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Add a rectangle shape to the first slide
        Aspose.Slides.IShape shape = firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add a text frame and set its text
        autoShape.AddTextFrame("See also");
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        textFrame.Paragraphs[0].Portions[0].Text = "See also";

        // Set an internal hyperlink on click that points to the second slide
        Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
        hyperlinkManager.SetInternalHyperlinkClick(secondSlide);

        // Save the presentation before exiting
        presentation.Save("SeeAlsoPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}