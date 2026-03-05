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

            // Add a rectangle auto shape to the slide
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 150, 75, 300, 100);

            // Access the text frame of the shape
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Get the first paragraph in the text frame
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Set line spacing (SpaceWithin) to 150 points (negative value indicates points)
            paragraph.ParagraphFormat.SpaceWithin = -150f;

            // Save the modified presentation
            presentation.Save("LineSpacing_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}