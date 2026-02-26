using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the background of the first slide to a solid white color
        presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.White;

        // Save the presentation
        string outputPath = "SlideBackgroundWhite.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}