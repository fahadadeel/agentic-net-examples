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

            // Configure slide show settings for looping and using timings
            var settings = presentation.SlideShowSettings;
            settings.Loop = true;
            settings.UseTimings = true;

            // Example: set the first effect of the first slide to repeat until end of slide
            if (presentation.Slides.Count > 0)
            {
                var slide = presentation.Slides[0];
                var timeline = slide.Timeline; // IAnimationTimeLine
                var mainSequence = timeline.MainSequence;
                if (mainSequence.Count > 0)
                {
                    var effect = mainSequence[0];
                    effect.Timing.RepeatUntilEndSlide = true;
                }
            }

            // Save the presentation
            presentation.Save("LoopedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}