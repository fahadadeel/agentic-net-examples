using System;

namespace HyperlinkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

            // Cast to AutoShape to work with text
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

            // Add a text frame
            autoShape.AddTextFrame("");

            // Get the text frame
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Set text for the portion
            textFrame.Paragraphs[0].Portions[0].Text = "Visit Aspose";

            // Get hyperlink manager for the portion
            Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

            // Set external hyperlink on click
            hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

            // Add another shape to demonstrate internal hyperlink
            Aspose.Slides.IShape targetShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 350, 150, 100, 100);
            Aspose.Slides.IAutoShape targetAutoShape = (Aspose.Slides.IAutoShape)targetShape;
            targetAutoShape.AddTextFrame("Target Slide");

            // Set internal hyperlink from the first shape's text to the same slide
            hyperlinkManager.SetInternalHyperlinkClick(slide);

            // Save the presentation
            presentation.Save("HyperlinkDemo_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}