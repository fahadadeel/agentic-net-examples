using System;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Add a shape for bulleted list
            var bulletShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 150);
            bulletShape.AddTextFrame("Bullet Item 1\nBullet Item 2\nBullet Item 3");
            var bulletTextFrame = bulletShape.TextFrame;

            // Apply bullet formatting
            foreach (var paragraph in bulletTextFrame.Paragraphs)
            {
                paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
                paragraph.ParagraphFormat.Bullet.Char = (char)8226; // •
            }

            // Add a shape for numbered list
            var numberShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 250, 400, 150);
            numberShape.AddTextFrame("Numbered Item 1\nNumbered Item 2\nNumbered Item 3");
            var numberTextFrame = numberShape.TextFrame;

            // Apply numbered list formatting
            foreach (var paragraph in numberTextFrame.Paragraphs)
            {
                paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            }

            // Save the presentation
            presentation.Save("BulletedNumberedLists_out.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}