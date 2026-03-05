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

        // Cast to AutoShape to add text
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
        autoShape.AddTextFrame("");
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        textFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

        // Obtain the hyperlink manager for the text portion
        Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

        // Set an external hyperlink on click
        hyperlinkManager.SetExternalHyperlinkClick("http://www.aspose.com");

        // Add a second slide to demonstrate changing the hyperlink to an internal link
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Change the hyperlink to point to the second slide
        hyperlinkManager.SetInternalHyperlinkClick(secondSlide);

        // Save the presentation in PPT format
        presentation.Save("MutableHyperlink_out.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
    }
}