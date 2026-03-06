using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the first slide number (logical constant)
        presentation.FirstSlideNumber = 5;

        // Set slide show type to PresentedBySpeaker (logical constant)
        presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with a title
        Aspose.Slides.IAutoShape titleShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
        titleShape.TextFrame.Text = "Logical Constants Example";

        // Save the presentation
        presentation.Save("LogicalConstants_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}