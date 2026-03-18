using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "output.pptx";

            // Create a new presentation
            var pres = new Aspose.Slides.Presentation();

            // Predefined boolean constants
            var enableTransition = true;
            var setLoop = true;
            var showMasterShapes = false;
            var usePresentedBySpeaker = true;

            // Access the first slide
            var slide = pres.Slides[0];

            // Apply transition if enabled
            if (enableTransition)
            {
                slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                slide.SlideShowTransition.AdvanceOnClick = false;
                slide.SlideShowTransition.AdvanceAfterTime = 3000;
            }

            // Set master slide property
            var master = pres.Masters[0];
            master.ShowMasterShapes = showMasterShapes;

            // Configure slide show settings
            pres.SlideShowSettings.Loop = setLoop;
            if (usePresentedBySpeaker)
            {
                pres.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();
            }
            else
            {
                pres.SlideShowSettings.SlideShowType = new Aspose.Slides.BrowsedAtKiosk();
            }

            // Save the presentation
            pres.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}