using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;
using System.Drawing;

namespace DesignPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the master theme (read‑only) and modify its format scheme
            Aspose.Slides.Theme.IMasterTheme masterTheme = presentation.MasterTheme;

            // Change the first fill style of the theme to a solid coral color
            Aspose.Slides.Theme.IFormatScheme formatScheme = masterTheme.FormatScheme;
            Aspose.Slides.IFillFormat fillFormat = formatScheme.FillStyles[0];
            fillFormat.FillType = Aspose.Slides.FillType.Solid;
            fillFormat.SolidFillColor.Color = System.Drawing.Color.Coral;

            // Change the second line style to a solid dark green color
            Aspose.Slides.ILineFormat lineFormat = formatScheme.LineStyles[1];
            lineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            lineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkGreen;

            // Optionally modify a background fill style
            Aspose.Slides.IFillFormat backgroundFill = formatScheme.BackgroundFillStyles[0];
            backgroundFill.FillType = Aspose.Slides.FillType.Solid;
            backgroundFill.SolidFillColor.Color = System.Drawing.Color.LightGray;

            // Save the presentation
            presentation.Save("CustomThemePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}