using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a new empty slide based on the first layout slide
        Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Add a title shape
        Aspose.Slides.IAutoShape titleShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 50);
        titleShape.TextFrame.Text = "Presentation Overview";

        // Add a content shape with bullet points
        Aspose.Slides.IAutoShape contentShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 120, 600, 300);
        contentShape.TextFrame.Text = "• Introduction\n• Objectives\n• Methodology\n• Results\n• Conclusion";

        // Save the presentation in PPT format
        presentation.Save("Overview.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
    }
}