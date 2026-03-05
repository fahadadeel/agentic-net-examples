using System;
using Aspose.Slides;
using Aspose.Slides.SlideShow;
using Aspose.Slides.Export;

namespace TransitionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Define the desired transition type and duration (in milliseconds)
            Aspose.Slides.SlideShow.TransitionType transitionType = Aspose.Slides.SlideShow.TransitionType.Fade;
            int transitionDuration = 2000; // 2 seconds

            // Apply the transition settings to each slide in the presentation
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                // Set transition type
                presentation.Slides[i].SlideShowTransition.Type = transitionType;
                // Set transition duration
                presentation.Slides[i].SlideShowTransition.Duration = transitionDuration;
            }

            // Save the presentation to disk
            presentation.Save("TransitionDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}