using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToGifExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string sourcePath = "input.pptx";

            // Path to the output GIF file
            string outputPath = "slide1.gif";

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath))
            {
                // Specify the slide index to export (1‑based)
                int[] slideIndices = new int[] { 1 };

                // Configure GIF export options (optional)
                Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
                gifOptions.DefaultDelay = 2000; // 2 seconds per frame
                gifOptions.TransitionFps = 30;

                // Save the selected slide as an animated GIF
                pres.Save(outputPath, slideIndices, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);
            }
        }
    }
}