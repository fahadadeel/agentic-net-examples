using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Configure transition for the first slide
            presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            presentation.Slides[0].SlideShowTransition.Duration = 2000; // 2 seconds
            presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
            presentation.Slides[0].SlideShowTransition.AdvanceAfter = true;
            presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000; // auto-advance after 3 seconds

            // Add a second slide and configure its transition
            Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            secondSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Push;
            secondSlide.SlideShowTransition.Duration = 1500; // 1.5 seconds
            secondSlide.SlideShowTransition.AdvanceOnClick = true;
            secondSlide.SlideShowTransition.AdvanceAfter = true;
            secondSlide.SlideShowTransition.AdvanceAfterTime = 4000; // auto-advance after 4 seconds

            // Set overall slideshow settings to use timings
            Aspose.Slides.SlideShowSettings settings = presentation.SlideShowSettings;
            settings.UseTimings = true;
            settings.ShowNarration = true;
            settings.ShowAnimation = true;

            // Save the presentation
            presentation.Save("SlideTransitions.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}