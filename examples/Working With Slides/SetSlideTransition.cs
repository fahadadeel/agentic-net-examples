using System;
using Aspose.Slides;
using Aspose.Slides.SlideShow;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

        // Apply a Circle transition
        firstSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Circle;
        // Set transition duration to 2000 ms (2 seconds)
        firstSlide.SlideShowTransition.Duration = 2000;
        // Advance on click and after 3000 ms (3 seconds)
        firstSlide.SlideShowTransition.AdvanceOnClick = true;
        firstSlide.SlideShowTransition.AdvanceAfter = true;
        firstSlide.SlideShowTransition.AdvanceAfterTime = 3000;

        // Add a second slide using the layout of the first slide
        Aspose.Slides.ILayoutSlide layout = presentation.Slides[0].LayoutSlide;
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(layout);

        // Apply a Fade transition to the second slide
        secondSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
        secondSlide.SlideShowTransition.Duration = 1500;
        secondSlide.SlideShowTransition.AdvanceOnClick = true;

        // Save the presentation
        presentation.Save("SlideTransitions_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}