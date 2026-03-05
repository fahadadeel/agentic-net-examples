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

            // Add a rectangle auto shape that will contain the text box
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                ShapeType.Rectangle, 100, 100, 300, 300);

            // Add a text frame with some sample text
            autoShape.AddTextFrame(
                "All these columns are forced to stay within a single text container -- " +
                "you can add or delete text and the new or remaining text automatically adjusts " +
                "itself to stay within the container.");

            // Access the text frame format to set column properties
            Aspose.Slides.ITextFrameFormat format = autoShape.TextFrame.TextFrameFormat;
            format.ColumnCount = 2;      // Set number of columns
            format.ColumnSpacing = 20;   // Set spacing between columns

            // Save the presentation
            presentation.Save(outPptxFileName, SaveFormat.Pptx);
        }
    }
}