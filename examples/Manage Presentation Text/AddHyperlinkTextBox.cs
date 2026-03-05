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

        // Add a rectangle AutoShape to act as a text box
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

        // Cast the shape to IAutoShape to access text-related methods
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add an empty TextFrame to the shape
        autoShape.AddTextFrame("");

        // Access the TextFrame
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Set the display text for the hyperlink
        textFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

        // Obtain the HyperlinkManager for the text portion
        Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

        // Assign an external hyperlink to the text
        hyperlinkManager.SetExternalHyperlinkClick("http://www.aspose.com");

        // Save the presentation as PPTX
        presentation.Save("TextBoxWithHyperlink_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}