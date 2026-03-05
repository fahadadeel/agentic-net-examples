using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Configure the presentation to be shown in speaker mode (includes speaker notes)
        presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

        // Save the presentation as HTML
        presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html);
    }
}