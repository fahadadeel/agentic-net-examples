using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace PresentationBulletsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get reference to the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape that will contain the bullet list
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

            // Add a text frame to the shape
            Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame(string.Empty);
            textFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Normal;

            // First bullet paragraph
            Aspose.Slides.IParagraph paragraph1 = new Aspose.Slides.Paragraph();
            paragraph1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            paragraph1.ParagraphFormat.Bullet.Char = (char)8226; // •
            paragraph1.ParagraphFormat.Bullet.Height = 100;
            Aspose.Slides.IPortion portion1 = new Aspose.Slides.Portion();
            portion1.Text = "First bullet item";
            paragraph1.Portions.Add(portion1);
            textFrame.Paragraphs.Add(paragraph1);

            // Second bullet paragraph
            Aspose.Slides.IParagraph paragraph2 = new Aspose.Slides.Paragraph();
            paragraph2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            paragraph2.ParagraphFormat.Bullet.Char = (char)8226;
            paragraph2.ParagraphFormat.Bullet.Height = 100;
            Aspose.Slides.IPortion portion2 = new Aspose.Slides.Portion();
            portion2.Text = "Second bullet item";
            paragraph2.Portions.Add(portion2);
            textFrame.Paragraphs.Add(paragraph2);

            // Third bullet paragraph
            Aspose.Slides.IParagraph paragraph3 = new Aspose.Slides.Paragraph();
            paragraph3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            paragraph3.ParagraphFormat.Bullet.Char = (char)8226;
            paragraph3.ParagraphFormat.Bullet.Height = 100;
            Aspose.Slides.IPortion portion3 = new Aspose.Slides.Portion();
            portion3.Text = "Third bullet item";
            paragraph3.Portions.Add(portion3);
            textFrame.Paragraphs.Add(paragraph3);

            // Save the presentation
            presentation.Save("BulletedPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}