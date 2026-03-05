using System;

namespace Example
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
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

            // Get its text frame
            Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

            // Remove the default empty paragraph
            textFrame.Paragraphs.RemoveAt(0);

            // First paragraph with custom numbered bullet starting at 1
            Aspose.Slides.Paragraph paragraph1 = new Aspose.Slides.Paragraph();
            paragraph1.Text = "First custom numbered item";
            paragraph1.ParagraphFormat.Depth = 0;
            paragraph1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)1;
            textFrame.Paragraphs.Add(paragraph1);

            // Second paragraph with custom numbered bullet starting at 5
            Aspose.Slides.Paragraph paragraph2 = new Aspose.Slides.Paragraph();
            paragraph2.Text = "Second custom numbered item";
            paragraph2.ParagraphFormat.Depth = 0;
            paragraph2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)5;
            textFrame.Paragraphs.Add(paragraph2);

            // Third paragraph with custom numbered bullet starting at 10
            Aspose.Slides.Paragraph paragraph3 = new Aspose.Slides.Paragraph();
            paragraph3.Text = "Third custom numbered item";
            paragraph3.ParagraphFormat.Depth = 0;
            paragraph3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            paragraph3.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)10;
            textFrame.Paragraphs.Add(paragraph3);

            // Save the presentation
            string outputPath = "CustomNumberedList_out.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}