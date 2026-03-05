using System;

public class Program
{
    public static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

        // Cast to AutoShape to work with text
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add a text frame
        autoShape.AddTextFrame("");

        // Get the first portion and set its text
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];
        portion.Text = "Visit Aspose";

        // Set an external hyperlink on click
        Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
        hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

        // Add a second slide to demonstrate an internal hyperlink
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(
            presentation.Slides[0].LayoutSlide);

        // Set an internal hyperlink on click (overwrites previous external link)
        hyperlinkManager.SetInternalHyperlinkClick(secondSlide);

        // Remove any hyperlink set for mouse over
        hyperlinkManager.RemoveHyperlinkMouseOver();

        // Save the presentation in PPT format
        presentation.Save("HyperlinkDemo.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
    }
}