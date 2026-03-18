using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Set the slide show type to PresentedBySpeaker (full screen)
            presentation.SlideShowSettings.SlideShowType = new PresentedBySpeaker();

            // Save the presentation
            presentation.Save("PresentedBySpeaker.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}