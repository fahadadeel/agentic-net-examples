using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;

namespace ManagePresentationColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set the background of the first slide to solid blue
            presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

            // Access the master theme's color scheme and change Accent1 to red
            Aspose.Slides.Theme.ColorScheme masterColorScheme = (Aspose.Slides.Theme.ColorScheme)presentation.MasterTheme.ColorScheme;
            masterColorScheme.Accent1.Color = System.Drawing.Color.Red;

            // Save the presentation in PPTX format
            presentation.Save("ManagedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}