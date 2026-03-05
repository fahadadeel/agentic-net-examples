using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the master theme (fully qualified)
        Aspose.Slides.Theme.IMasterTheme masterTheme = presentation.MasterTheme;

        // Set a custom name for the theme
        masterTheme.Name = "MyCustomTheme";

        // Modify the first fill style in the format scheme to a solid blue fill
        masterTheme.FormatScheme.FillStyles[0].FillType = Aspose.Slides.FillType.Solid;
        masterTheme.FormatScheme.FillStyles[0].SolidFillColor.Color = System.Drawing.Color.Blue;

        // Change the font scheme name
        masterTheme.FontScheme.Name = "CustomFontScheme";

        // Save the presentation before exiting
        presentation.Save("CustomThemePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}