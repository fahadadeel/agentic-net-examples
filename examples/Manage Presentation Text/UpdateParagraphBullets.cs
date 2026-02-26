using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BulletManagementExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

            // Cast the shape to IAutoShape to work with text
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

            // Add a text frame with multiple lines (each line becomes a paragraph)
            autoShape.AddTextFrame("First item\nSecond item\nThird item");

            // Iterate through each paragraph and enable bullets
            for (int i = 0; i < autoShape.TextFrame.Paragraphs.Count; i++)
            {
                Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[i];

                // Enable bullet and set bullet type to symbol
                paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;

                // Set bullet character (e.g., solid bullet)
                paragraph.ParagraphFormat.Bullet.Char = (char)8226; // Unicode bullet

                // Apply default indent shifts for the bullet
                paragraph.ParagraphFormat.Bullet.ApplyDefaultParagraphIndentsShifts();
            }

            // Save the modified presentation
            presentation.Save("ModifiedBullets_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}