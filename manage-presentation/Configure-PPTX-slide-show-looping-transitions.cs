using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideShowConfigurator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Configure slide show settings
                presentation.SlideShowSettings.Loop = true;                     // Enable looping
                presentation.SlideShowSettings.UseTimings = true;              // Use timings
                presentation.SlideShowSettings.SlideShowType = new PresentedBySpeaker(); // Full‑screen speaker mode

                // Ensure there are at least three slides
                while (presentation.Slides.Count < 3)
                {
                    presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                }

                // Slide 1 transition
                presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                presentation.Slides[0].SlideShowTransition.Duration = 2000;          // 2 seconds
                presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
                presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds

                // Slide 2 transition
                presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Wipe;
                presentation.Slides[1].SlideShowTransition.Duration = 2500;          // 2.5 seconds
                presentation.Slides[1].SlideShowTransition.AdvanceOnClick = true;
                presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 4000; // 4 seconds

                // Slide 3 transition
                presentation.Slides[2].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;
                presentation.Slides[2].SlideShowTransition.Duration = 3000;          // 3 seconds
                presentation.Slides[2].SlideShowTransition.AdvanceOnClick = true;
                presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = 5000; // 5 seconds

                // Save the presentation
                presentation.Save("ConfiguredSlideShow.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}