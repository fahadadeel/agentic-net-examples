using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

            // Cast to IAutoShape to work with text
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

            // Add an empty text frame
            autoShape.AddTextFrame("");

            // Access the text frame
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Set the display text
            textFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

            // Get the hyperlink manager for the portion
            Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

            // Assign an external URL hyperlink on click
            hyperlinkManager.SetExternalHyperlinkClick("http://www.aspose.com");

            // Save the presentation
            presentation.Save("HyperlinkDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}