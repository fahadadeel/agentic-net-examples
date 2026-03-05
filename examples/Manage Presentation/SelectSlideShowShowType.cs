using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the slide show type (e.g., Presented by a speaker)
        presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

        // Save the presentation before exiting
        presentation.Save("PresentedBySpeaker.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}