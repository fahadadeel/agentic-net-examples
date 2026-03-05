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

        // Add a rectangle shape to hold the bullet list
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);
        autoShape.AddTextFrame("Placeholder");

        // Get the text frame and clear default paragraph
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        textFrame.Paragraphs.Clear();

        // Level 0 bullet
        Aspose.Slides.IParagraph para0 = new Aspose.Slides.Paragraph();
        para0.ParagraphFormat.Depth = 0;
        para0.Text = "Level 1 Item";
        textFrame.Paragraphs.Add(para0);

        // Level 1 bullet
        Aspose.Slides.IParagraph para1 = new Aspose.Slides.Paragraph();
        para1.ParagraphFormat.Depth = 1;
        para1.Text = "Level 2 Item";
        textFrame.Paragraphs.Add(para1);

        // Level 2 bullet
        Aspose.Slides.IParagraph para2 = new Aspose.Slides.Paragraph();
        para2.ParagraphFormat.Depth = 2;
        para2.Text = "Level 3 Item";
        textFrame.Paragraphs.Add(para2);

        // Save the presentation
        presentation.Save("MultilevelBullets.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}