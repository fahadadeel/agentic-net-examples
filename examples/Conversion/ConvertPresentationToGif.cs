using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Load the PowerPoint presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Configure GIF export options
        Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
        gifOptions.FrameSize = new Size(960, 720);      // Set the size of the resulting GIF
        gifOptions.DefaultDelay = 2000;                // Delay for each slide in milliseconds
        gifOptions.TransitionFps = 35;                 // Frames per second for transitions

        // Save the presentation as an animated GIF
        presentation.Save("output.gif", Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

        // Release resources
        presentation.Dispose();
    }
}