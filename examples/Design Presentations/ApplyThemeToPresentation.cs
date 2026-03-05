using System;

namespace ApplyThemeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the external theme file (.thmx)
            string themePath = "example.thmx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Apply the external theme to the first master slide and all its dependent slides
            Aspose.Slides.IMasterSlide themedMaster = presentation.Masters[0].ApplyExternalThemeToDependingSlides(themePath);

            // Save the themed presentation
            presentation.Save("ThemedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}