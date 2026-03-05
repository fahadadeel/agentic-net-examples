using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Enable timings in slide show settings
        presentation.SlideShowSettings.UseTimings = true;

        // Set transition duration for the first slide (if any)
        if (presentation.Slides.Count > 0)
        {
            presentation.Slides[0].SlideShowTransition.Duration = 2000; // 2 seconds
        }

        // Configure default animation delay using PresentationAnimationsGenerator
        using (Aspose.Slides.Export.PresentationAnimationsGenerator animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation))
        {
            animationsGenerator.DefaultDelay = 500; // 0.5 second default delay

            // Optional: handle NewAnimation event to inspect each animation
            animationsGenerator.NewAnimation += (Aspose.Slides.Export.IPresentationAnimationPlayer animationPlayer) =>
            {
                Console.WriteLine($"Animation total duration: {animationPlayer.Duration} ms");
            };

            // Run the generator to apply timings
            animationsGenerator.Run(presentation.Slides);
        }

        // Save the presentation before exiting
        presentation.Save("ConfiguredTimings.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}