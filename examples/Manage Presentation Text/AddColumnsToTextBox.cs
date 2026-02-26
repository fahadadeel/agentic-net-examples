using System;

namespace PresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 300);

            // Add a text frame with initial text
            autoShape.AddTextFrame("All these columns are forced to stay within a single text container -- you can add or delete text and the new or remaining text automatically adjusts itself to stay within the container. You cannot have text spill over from one container to other, though -- because PowerPoint's column options for text are limited!");

            // Access the text frame format
            Aspose.Slides.ITextFrameFormat format = autoShape.TextFrame.TextFrameFormat;

            // Set the number of columns
            format.ColumnCount = 2;

            // Set column spacing (optional)
            format.ColumnSpacing = 20;

            // Save the presentation
            presentation.Save("ColumnsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}