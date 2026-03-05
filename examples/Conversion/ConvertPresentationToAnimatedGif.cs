using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            System.String inputPath = "input.pptx";
            // Path for the output GIF file
            System.String outputPath = "output.gif";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure GIF export options
            Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
            gifOptions.FrameSize = new System.Drawing.Size(960, 720); // Frame size
            gifOptions.DefaultDelay = 2000; // Delay per slide in milliseconds
            gifOptions.TransitionFps = 35; // Frames per second for transitions

            // Save the presentation as an animated GIF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

            // Release resources
            presentation.Dispose();
        }
    }
}