using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output GIF paths (can be passed via command line arguments)
        string inputPath = args.Length > 0 ? args[0] : "input.gif";
        string outputPath = args.Length > 1 ? args[1] : "output.gif";

        // Rectangle overlay parameters
        int overlayX = 10;
        int overlayY = 10;
        int overlayWidth = 50;
        int overlayHeight = 30;

        // Load the existing GIF image
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Create a semi‑transparent red brush for the overlay
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
            {
                // Iterate through all frames and draw the rectangle on each one
                for (int i = 0; i < gif.PageCount; i++)
                {
                    // Set the current active frame
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                    // Obtain a Graphics object for the active frame
                    Graphics graphics = new Graphics(gif.ActiveFrame);

                    // Draw the overlay rectangle
                    graphics.FillRectangle(brush, new Rectangle(overlayX, overlayY, overlayWidth, overlayHeight));
                }
            }

            // Preserve animation properties (e.g., loop count) when saving
            GifOptions saveOptions = new GifOptions
            {
                LoopsCount = gif.LoopsCount
            };

            // Save the modified GIF
            gif.Save(outputPath, saveOptions);
        }
    }
}