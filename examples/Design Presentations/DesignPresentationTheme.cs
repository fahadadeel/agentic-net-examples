using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Path to the external theme file (.thmx)
        string themePath = "CustomTheme.thmx";

        // Get the first master slide in the presentation
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Apply the external theme to the master slide and all dependent slides
        Aspose.Slides.IMasterSlide newMaster = masterSlide.ApplyExternalThemeToDependingSlides(themePath);

        // Modify an element of the master theme (e.g., change the first line style color to Red)
        presentation.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation to a file
        presentation.Save("PresentationWithTheme.pptx", SaveFormat.Pptx);
    }
}