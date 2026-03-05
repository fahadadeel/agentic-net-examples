using System;
using System.Drawing;
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

        // Add a rectangle auto shape to hold the bullet list
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 500, 300);

        // Get the text frame of the shape
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Remove the default paragraph
        textFrame.Paragraphs.RemoveAt(0);

        // First bullet point - Symbol bullet
        Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
        para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para1.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226); // bullet character
        para1.Text = "Clear structure";
        para1.ParagraphFormat.Indent = 20f;
        para1.ParagraphFormat.Bullet.Color.ColorType = Aspose.Slides.ColorType.RGB;
        para1.ParagraphFormat.Bullet.Color.Color = System.Drawing.Color.Black;
        para1.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
        textFrame.Paragraphs.Add(para1);

        // Second bullet point - Symbol bullet
        Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
        para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para2.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226);
        para2.Text = "Easy to read";
        para2.ParagraphFormat.Indent = 20f;
        para2.ParagraphFormat.Bullet.Color.ColorType = Aspose.Slides.ColorType.RGB;
        para2.ParagraphFormat.Bullet.Color.Color = System.Drawing.Color.Black;
        para2.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
        textFrame.Paragraphs.Add(para2);

        // Third bullet point - Numbered bullet
        Aspose.Slides.Paragraph para3 = new Aspose.Slides.Paragraph();
        para3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
        para3.ParagraphFormat.Bullet.NumberedBulletStyle = Aspose.Slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain;
        para3.Text = "Helps emphasize key points";
        para3.ParagraphFormat.Indent = 20f;
        para3.ParagraphFormat.Bullet.Color.ColorType = Aspose.Slides.ColorType.RGB;
        para3.ParagraphFormat.Bullet.Color.Color = System.Drawing.Color.Black;
        para3.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
        textFrame.Paragraphs.Add(para3);

        // Save the presentation
        presentation.Save("BulletListPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Dispose the presentation
        presentation.Dispose();
    }
}