using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set transition type for the first slide
        presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Circle;

        // Add a second slide using the layout of the first slide
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        // Set transition type for the second slide
        secondSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

        // Save the presentation in PPTX format
        presentation.Save("SetSlideTransitions_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}