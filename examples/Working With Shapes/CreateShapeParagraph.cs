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

        // Add a rectangle AutoShape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);

        // Add an empty TextFrame to the shape
        autoShape.AddTextFrame(" ");

        // Access the TextFrame
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Create a new paragraph using ParagraphFactory
        Aspose.Slides.ParagraphFactory paragraphFactory = new Aspose.Slides.ParagraphFactory();
        Aspose.Slides.IParagraph paragraph = paragraphFactory.CreateParagraph();

        // Set paragraph text
        paragraph.Text = "Centered paragraph created via Aspose.Slides";

        // Set paragraph alignment to center
        paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

        // Add the paragraph to the TextFrame
        textFrame.Paragraphs.Add(paragraph);

        // Save the presentation
        presentation.Save("ParagraphDemo_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}