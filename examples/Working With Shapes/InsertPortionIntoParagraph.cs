using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);

            // Add a TextFrame with initial text
            autoShape.AddTextFrame("Hello ");

            // Access the first paragraph
            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

            // Create a new Portion
            Aspose.Slides.Portion newPortion = new Aspose.Slides.Portion("World");

            // Insert the new portion at index 1 (after the existing portion)
            paragraph.Portions.Insert(1, newPortion);

            // Save the presentation
            presentation.Save("InsertPortion_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}