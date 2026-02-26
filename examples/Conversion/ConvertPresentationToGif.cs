using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the source PowerPoint presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Configure GIF export options
        Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
        gifOptions.DefaultDelay = 2000;      // 2 seconds per slide
        gifOptions.TransitionFps = 35;       // Higher FPS for smoother transitions

        // Save the presentation as an animated GIF
        pres.Save("output.gif", Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

        // Release resources
        pres.Dispose();
    }
}