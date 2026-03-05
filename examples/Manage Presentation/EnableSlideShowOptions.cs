using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Enable slide show options
        presentation.SlideShowSettings.ShowMediaControls = true;
        presentation.SlideShowSettings.ShowAnimation = true;
        presentation.SlideShowSettings.ShowNarration = true;
        presentation.SlideShowSettings.Loop = true;

        // Save the presentation
        string outputPath = "ShowOptionsPresentation.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}