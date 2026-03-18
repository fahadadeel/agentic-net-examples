using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();

            // First slide already exists
            var slide1 = presentation.Slides[0];

            // Add additional slides
            var slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            var slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Apply transitions
            slide1.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            slide2.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Push;
            slide3.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;

            // Optional: set transition duration (milliseconds)
            slide1.SlideShowTransition.Duration = 2000;
            slide2.SlideShowTransition.Duration = 2500;
            slide3.SlideShowTransition.Duration = 3000;

            // Save the presentation
            presentation.Save("SlideTransitions.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}