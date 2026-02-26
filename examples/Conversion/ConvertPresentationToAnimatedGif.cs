using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        System.String inputPath = "input.pptx";
        // Path where the animated GIF will be saved
        System.String outputPath = "output.gif";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create GIF export options (using default settings)
        Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
        // Optional: set frame size, delay and FPS (defaults are used if omitted)
        gifOptions.FrameSize = new System.Drawing.Size(960, 720);
        gifOptions.DefaultDelay = 1000; // milliseconds
        gifOptions.TransitionFps = 25;   // frames per second

        // Save the presentation as an animated GIF
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

        // Release resources
        presentation.Dispose();
    }
}