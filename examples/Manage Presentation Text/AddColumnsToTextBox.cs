using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to the slide
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 300);

        // Add a text frame with sample text
        autoShape.AddTextFrame(
            "All these columns are limited to be within a single text container -- you can add or delete text and the new or remaining text automatically adjusts itself to stay within the container. You cannot have text spill over from one container to other, though -- because PowerPoint's column options for text are limited!");

        // Get the text frame format to configure columns
        Aspose.Slides.ITextFrameFormat format = autoShape.TextFrame.TextFrameFormat;

        // Set the number of columns and spacing between them
        format.ColumnCount = 3;
        format.ColumnSpacing = 10;

        // Save the presentation to a file
        presentation.Save("ColumnCount.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}