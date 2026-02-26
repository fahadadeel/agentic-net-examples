using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToGif
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check for required arguments: source file and destination file
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ConvertToGif <source-ppt-or-pptx> <output-gif>");
                return;
            }

            // Source presentation path (PPT or PPTX)
            string sourcePath = args[0];
            // Destination GIF path
            string destinationPath = args[1];

            // Load the presentation
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Create GIF export options (optional customization)
                GifOptions gifOptions = new GifOptions();
                // Example: set frame size for the resulting GIF
                gifOptions.FrameSize = new Size(960, 720);
                // Example: set default delay between frames (in milliseconds)
                gifOptions.DefaultDelay = 1000;
                // Example: set transition frames per second
                gifOptions.TransitionFps = 25;

                // Save the presentation as an animated GIF
                presentation.Save(destinationPath, SaveFormat.Gif, gifOptions);
            }

            Console.WriteLine("Conversion completed: " + destinationPath);
        }
    }
}