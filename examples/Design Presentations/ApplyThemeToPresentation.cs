using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation file
        string presentationPath = "input.pptx";
        // Path to the external theme file (.thmx)
        string themePath = "theme.thmx";
        // Path for the output presentation
        string outputPath = "output.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath))
        {
            // Get the first master slide from the presentation
            Aspose.Slides.IMasterSlide masterSlide = pres.Masters[0];

            // Apply the external theme to the master slide and all dependent slides
            Aspose.Slides.IMasterSlide newMaster = masterSlide.ApplyExternalThemeToDependingSlides(themePath);

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}