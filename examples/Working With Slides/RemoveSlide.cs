using System;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Load the presentation from a PPTX file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Ensure there is at least one slide to remove
            if (presentation.Slides.Count > 0)
            {
                // Get the slide to remove (e.g., the first slide)
                Aspose.Slides.ISlide slideToRemove = presentation.Slides[0];
                // Remove the slide from the presentation
                slideToRemove.Remove();
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}