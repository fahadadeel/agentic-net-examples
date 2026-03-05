using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the presentation from a file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("Input.pptx"))
        {
            // Apply a Fade transition to the first slide
            presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            // Set the transition duration to 2 seconds (2000 ms)
            presentation.Slides[0].SlideShowTransition.Duration = 2000;
            // Advance the slide on mouse click
            presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;

            // If a second slide exists, apply a Wipe transition with auto‑advance after 5 seconds
            if (presentation.Slides.Count > 1)
            {
                presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Wipe;
                presentation.Slides[1].SlideShowTransition.AdvanceAfter = true;
                presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;
            }

            // Save the modified presentation
            presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}