using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a title shape
        Aspose.Slides.IShape titleShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 50);
        Aspose.Slides.IAutoShape titleAutoShape = (Aspose.Slides.IAutoShape)titleShape;
        titleAutoShape.TextFrame.Text = "Presentation Overview";

        // Add a subtitle shape
        Aspose.Slides.IShape subtitleShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 120, 600, 50);
        Aspose.Slides.IAutoShape subtitleAutoShape = (Aspose.Slides.IAutoShape)subtitleShape;
        subtitleAutoShape.TextFrame.Text = "Generated using Aspose.Slides";

        // Save the presentation
        presentation.Save("Overview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}