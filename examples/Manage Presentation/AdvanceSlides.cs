using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add two additional empty slides so we have three slides in total
        Aspose.Slides.ISlide slide0 = presentation.Slides[0];
        Aspose.Slides.ISlide slide1 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Configure advanced transition for slide 0
        slide0.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Circle;
        slide0.SlideShowTransition.AdvanceOnClick = true;
        slide0.SlideShowTransition.AdvanceAfterTime = 3000u;

        // Configure advanced transition for slide 1
        slide1.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Comb;
        slide1.SlideShowTransition.AdvanceOnClick = true;
        slide1.SlideShowTransition.AdvanceAfterTime = 5000u;

        // Configure advanced transition for slide 2
        slide2.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;
        slide2.SlideShowTransition.AdvanceOnClick = true;
        slide2.SlideShowTransition.AdvanceAfterTime = 7000u;

        // Save the presentation before exiting
        presentation.Save("AdvancedSlides.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}