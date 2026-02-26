using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first master slide
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Apply an external theme (.thmx) to the master slide and all dependent slides
            // Replace "theme.thmx" with the actual path to your theme file
            masterSlide.ApplyExternalThemeToDependingSlides("theme.thmx");

            // Save the themed presentation as PPTX
            presentation.Save("ThemedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}