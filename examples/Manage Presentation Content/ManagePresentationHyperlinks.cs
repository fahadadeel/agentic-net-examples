using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

        // Cast to AutoShape
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add a text frame and set text
        autoShape.AddTextFrame("");
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        textFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

        // Get the portion to apply hyperlink
        Aspose.Slides.IPortion portion = textFrame.Paragraphs[0].Portions[0];

        // Set an external hyperlink on click
        Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
        hyperlinkManager.SetExternalHyperlinkClick("http://www.aspose.com");

        // Add a new slide to link to
        Aspose.Slides.ISlide targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Set an internal hyperlink on click to the new slide
        hyperlinkManager.SetInternalHyperlinkClick(targetSlide);

        // Save the presentation
        presentation.Save("HyperlinksDemo.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
    }
}