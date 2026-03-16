using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats;

// Create a PNG image that will serve as the canvas
using (FileStream canvasStream = new FileStream(@"C:\temp\canvas.png", FileMode.Create))
{
    // Set up PNG options and associate the stream as the source
    PngOptions pngOptions = new PngOptions();
    pngOptions.Source = new StreamSource(canvasStream);

    // Create a 500x500 image
    using (Image canvas = Image.Create(pngOptions, 500, 500))
    {
        // Initialize Graphics for the canvas
        Graphics graphics = new Graphics(canvas);

        // Fill the background with a light color
        graphics.Clear(Color.LightGray);

        // Load an external image that will be drawn onto the canvas
        // Replace the path with an existing image file on your system
        using (Image overlay = Image.Load(@"C:\temp\sample.jpg"))
        {
            // 1. Draw the overlay at its original size at position (50,50)
            graphics.DrawImage(overlay, 50, 50);

            // 2. Draw the overlay scaled to a 150x100 rectangle at position (250,30)
            graphics.DrawImage(overlay, new Rectangle(250, 30, 150, 100));

            // 3. Draw a portion of the overlay (top‑left 100x100) into a 120x120 rectangle at (100,300)
            Rectangle srcRect = new Rectangle(0, 0, 100, 100);
            Rectangle destRect = new Rectangle(100, 300, 120, 120);
            graphics.DrawImage(overlay, srcRect, destRect, GraphicsUnit.Pixel);
        }

        // Save the final canvas image (the stream is already linked to the file)
        canvas.Save();
    }
}