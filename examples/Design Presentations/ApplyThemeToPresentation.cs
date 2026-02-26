using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThemeApplicationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the external theme file (.thmx)
            string externalThemePath = "example.thmx";

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first master slide in the presentation
                Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

                // Apply the external theme to the master slide and all dependent slides
                masterSlide.ApplyExternalThemeToDependingSlides(externalThemePath);

                // Save the themed presentation
                presentation.Save("ThemedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}