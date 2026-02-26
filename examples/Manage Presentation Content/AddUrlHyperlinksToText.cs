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

        // Add a rectangle auto shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

        // Cast the shape to IAutoShape
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add a text frame to the shape
        autoShape.AddTextFrame("");
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Set the text of the first portion
        textFrame.Paragraphs[0].Portions[0].Text = "Visit Aspose";

        // Obtain the hyperlink manager for the portion
        Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

        // Set an external hyperlink on click
        hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

        // Save the presentation
        presentation.Save("HyperlinkDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}