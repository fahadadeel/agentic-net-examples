using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";
        // Path to the output PPTX file
        string outputPath = "output.pptx";

        // Load the presentation from file
        Presentation presentation = new Presentation(inputPath);

        // Set the slide show type to full‑screen mode for viewing
        presentation.SlideShowSettings.SlideShowType = new PresentedBySpeaker();

        // Save the presentation before exiting
        presentation.Save(outputPath, SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}