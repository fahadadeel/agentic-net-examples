using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation (modify as needed)
        string inputPath = "input.pptx";

        // Path where the modified PPTX will be saved
        string outputPath = "output.pptx";

        // Load the presentation from the file system
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Enable media controls for the slide show
        presentation.SlideShowSettings.ShowMediaControls = true;

        // Save the modified presentation as PPTX
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}