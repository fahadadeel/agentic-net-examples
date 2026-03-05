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

        // Add a rectangle auto shape to hold the list
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

        // Access the text frame of the shape
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

        // Remove the default empty paragraph
        textFrame.Paragraphs.RemoveAt(0);

        // First numbered paragraph
        Aspose.Slides.Paragraph paragraph1 = new Aspose.Slides.Paragraph();
        paragraph1.Text = "First item";
        paragraph1.ParagraphFormat.Depth = 0;
        paragraph1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
        paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
        textFrame.Paragraphs.Add(paragraph1);

        // Second numbered paragraph
        Aspose.Slides.Paragraph paragraph2 = new Aspose.Slides.Paragraph();
        paragraph2.Text = "Second item";
        paragraph2.ParagraphFormat.Depth = 0;
        paragraph2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
        paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
        textFrame.Paragraphs.Add(paragraph2);

        // Third numbered paragraph
        Aspose.Slides.Paragraph paragraph3 = new Aspose.Slides.Paragraph();
        paragraph3.Text = "Third item";
        paragraph3.ParagraphFormat.Depth = 0;
        paragraph3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
        paragraph3.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
        textFrame.Paragraphs.Add(paragraph3);

        // Save the presentation
        string outputPath = "ManagedLists_out.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}