using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape that will contain the numbered list
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

        // Access the text frame of the shape
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

        // Remove the default empty paragraph
        textFrame.Paragraphs.RemoveAt(0);

        // First list item
        Aspose.Slides.Paragraph paragraph1 = new Aspose.Slides.Paragraph();
        paragraph1.Text = "First item";
        paragraph1.ParagraphFormat.Depth = 0;
        paragraph1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
        paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)1;
        textFrame.Paragraphs.Add(paragraph1);

        // Second list item
        Aspose.Slides.Paragraph paragraph2 = new Aspose.Slides.Paragraph();
        paragraph2.Text = "Second item";
        paragraph2.ParagraphFormat.Depth = 0;
        paragraph2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
        paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)2;
        textFrame.Paragraphs.Add(paragraph2);

        // Third list item
        Aspose.Slides.Paragraph paragraph3 = new Aspose.Slides.Paragraph();
        paragraph3.Text = "Third item";
        paragraph3.ParagraphFormat.Depth = 0;
        paragraph3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
        paragraph3.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)3;
        textFrame.Paragraphs.Add(paragraph3);

        // Save the presentation (numbered lists are now visible)
        presentation.Save("NumberedList_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}