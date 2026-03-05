using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Set slide background to LightBlue
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;

        // Add a rectangle shape and set its fill color to Accent1 from the theme
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 150, 200, 100);
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;

        // Save the presentation as PPT
        presentation.Save("ManagedContentColor.ppt", SaveFormat.Ppt);

        // Dispose the presentation
        presentation.Dispose();
    }
}