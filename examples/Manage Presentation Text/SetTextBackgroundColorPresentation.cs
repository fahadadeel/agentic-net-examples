using System;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Get the first shape (assumed to be an AutoShape with text)
        Aspose.Slides.IShape shape = slide.Shapes[0];
        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

        if (autoShape != null && autoShape.TextFrame != null)
        {
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            if (textFrame.Paragraphs.Count > 0)
            {
                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

                if (paragraph.Portions.Count > 0)
                {
                    Aspose.Slides.IPortion portion = paragraph.Portions[0];

                    // Set the text background (highlight) color to Yellow
                    portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;
                }
            }
        }

        // Save the updated presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}