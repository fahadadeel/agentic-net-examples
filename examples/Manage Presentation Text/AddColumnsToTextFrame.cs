using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file name
        string outPptxFileName = "ColumnsDemo.pptx";

        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 300);

            // Add a text frame with initial text
            Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame(
                "All these columns are forced to stay within a single text container -- you can add or delete text and the new or remaining text automatically adjusts itself to stay within the container.");

            // Access the text frame format
            Aspose.Slides.ITextFrameFormat format = textFrame.TextFrameFormat;

            // Set the number of columns
            format.ColumnCount = 2;

            // Set spacing between columns (optional)
            format.ColumnSpacing = 20;

            // Save the presentation
            presentation.Save(outPptxFileName, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}