using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the transition type for the first slide
        presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Circle;

        // Optionally set the transition duration (in milliseconds)
        presentation.Slides[0].SlideShowTransition.Duration = 3000;

        // Save the presentation to disk
        presentation.Save("SlideTransition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}