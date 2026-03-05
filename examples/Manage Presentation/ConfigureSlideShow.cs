using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set slide show type to PresentedBySpeaker (full screen)
        presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

        // Define slide range for the slide show (slides 1 to 3)
        presentation.SlideShowSettings.Slides = new Aspose.Slides.SlidesRange { Start = 1, End = 3 };

        // Show media controls during slide show
        presentation.SlideShowSettings.ShowMediaControls = true;

        // Apply better slide transitions
        // Slide 0
        presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Circle;
        presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = (uint)3000;

        // Slide 1
        presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Comb;
        presentation.Slides[1].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = (uint)5000;

        // Slide 2
        presentation.Slides[2].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;
        presentation.Slides[2].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = (uint)7000;

        // Save the presentation in PPTX format
        presentation.Save("ConfiguredSlideShow.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}