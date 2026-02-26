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

        // Add a rectangle auto shape to hold the text
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50,   // x
            50,   // y
            400,  // width
            300   // height
        );

        // Access the text frame of the shape
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

        // Remove the default empty paragraph
        textFrame.Paragraphs.RemoveAt(0);

        // Create a paragraph with numbered bullet
        Aspose.Slides.Paragraph paragraph = new Aspose.Slides.Paragraph();
        paragraph.Text = "Why Use Numbered Lists?";
        paragraph.ParagraphFormat.Depth = 0;
        paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
        paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)1;

        // Add the paragraph to the text frame
        textFrame.Paragraphs.Add(paragraph);

        // Save the presentation as PPTX
        presentation.Save("NumberedListPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}