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

        // Add a rectangle AutoShape as a text box
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

        // Cast the shape to AutoShape
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add an empty TextFrame to the shape
        autoShape.AddTextFrame("");

        // Access the TextFrame
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Set the text of the first portion
        textFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

        // Get the HyperlinkManager for the portion
        Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

        // Set an external hyperlink on click
        hyperlinkManager.SetExternalHyperlinkClick("http://www.aspose.com");

        // Save the presentation
        presentation.Save("TextBoxWithHyperlink_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}