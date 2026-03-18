using System;
using Aspose.Slides.Export;

namespace SlideShowDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Activate slide show settings
                presentation.SlideShowSettings.Loop = true;                     // Loop the slide show
                presentation.SlideShowSettings.ShowAnimation = true;           // Show animations
                presentation.SlideShowSettings.ShowMediaControls = true;       // Show media controls
                presentation.SlideShowSettings.ShowNarration = false;          // Hide narration
                presentation.SlideShowSettings.UseTimings = true;              // Use slide timings

                // Set the slide show type (full‑screen speaker mode)
                presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

                // Save the presentation
                presentation.Save("SlideShowDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}