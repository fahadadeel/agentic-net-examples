using System;
using System.Drawing;

namespace ThemeAccessExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the master theme of the presentation
            Aspose.Slides.Theme.IMasterTheme masterTheme = pres.MasterTheme;

            // Change the first line style fill color to Red
            masterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

            // Set the third fill style to solid and change its color to ForestGreen
            masterTheme.FormatScheme.FillStyles[2].FillType = Aspose.Slides.FillType.Solid;
            masterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

            // Modify the outer shadow distance of the third effect style
            masterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

            // Save the presentation before exiting
            pres.Save("ThemeAccessOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}