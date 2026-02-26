using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetPresentationBackgroundColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set the background of the first slide to a solid blue color
            presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation to a file
            presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}