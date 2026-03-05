using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Configure GIF export options with a custom frame delay (in milliseconds)
        Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
        gifOptions.DefaultDelay = 2000; // 2 seconds per slide

        // Save the presentation as an animated GIF
        presentation.Save("output.gif", Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

        // Clean up resources
        presentation.Dispose();
    }
}