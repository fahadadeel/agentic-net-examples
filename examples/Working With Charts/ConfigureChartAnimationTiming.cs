using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Enable timings in slide show settings
            presentation.SlideShowSettings.UseTimings = true;

            // Set transition duration for the first slide (3 seconds)
            presentation.Slides[0].SlideShowTransition.Duration = 3000;

            // Configure animation generator with a default delay
            using (Aspose.Slides.Export.PresentationAnimationsGenerator animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation))
            {
                animationsGenerator.DefaultDelay = 500; // 0.5 second default delay

                // Subscribe to the NewAnimation event to inspect animation timing
                animationsGenerator.NewAnimation += (Aspose.Slides.Export.IPresentationAnimationPlayer animationPlayer) =>
                {
                    Console.WriteLine($"Animation total duration: {animationPlayer.Duration} ms");
                    // Example: set time position to start (optional)
                    animationPlayer.SetTimePosition(0);
                };

                // Generate animations for all slides
                animationsGenerator.Run(presentation.Slides);
            }

            // Save the presentation before exiting
            presentation.Save("AnimatedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}