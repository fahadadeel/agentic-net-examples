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

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Set the background type to own background
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;

        // Set the fill type to solid color
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;

        // Set the solid fill color to blue
        slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

        // Save the presentation to a file
        presentation.Save("BackgroundColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}