using System;

namespace SlideShowTimingsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Enable the use of slide timings in the slide show
            presentation.SlideShowSettings.UseTimings = true;

            // Set the slide show type (optional, e.g., presented by speaker)
            presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

            // Save the presentation in PPTX format
            presentation.Save("SlideShowTimings.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}