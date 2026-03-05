using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 300);

        // Add a TextFrame with initial text
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame(
            "All these columns are limited to be within a single text container -- you can add or delete text and the new or remaining text automatically adjusts itself to stay within the container. You cannot have text flow from one container to other though -- PowerPoint's column options for text are limited!");

        // Set the number of columns and spacing
        Aspose.Slides.ITextFrameFormat format = textFrame.TextFrameFormat;
        format.ColumnCount = 3;
        format.ColumnSpacing = 10;

        // Save the presentation
        presentation.Save("ColumnsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}