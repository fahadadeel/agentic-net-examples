using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

// Define paths
string dir = @"c:\temp\";
string sourcePath = Path.Combine(dir, "source.png");
string outputPath = Path.Combine(dir, "output.bmp");

// Load the source raster image
using (Image srcImg = Image.Load(sourcePath))
{
    // Cast to RasterImage to access pixel dimensions
    RasterImage raster = (RasterImage)srcImg;

    // Specify the region of the source image to render
    // Example: rectangle starting at (50,50) with size 200x150
    Rectangle srcRect = new Rectangle(50, 50, 200, 150);

    // Ensure the source rectangle does not exceed the image bounds
    srcRect = Rectangle.Intersect(srcRect, raster.Bounds);

    // Define the size of the vector canvas (BMP will have the same dimensions)
    int canvasWidth = srcRect.Width;
    int canvasHeight = srcRect.Height;

    // Create a WMF recorder graphics object (vector canvas)
    // Frame defines the logical size of the canvas; DPI is set to 96 (standard screen resolution)
    Rectangle frame = new Rectangle(0, 0, canvasWidth, canvasHeight);
    int dpi = 96;
    WmfRecorderGraphics2D graphics = new WmfRecorderGraphics2D(frame, dpi);

    // Destination rectangle on the canvas where the source region will be drawn
    // Here we draw it at the origin (0,0) with the same size as the source region
    Rectangle destRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);

    // Render the specified portion of the raster image onto the vector canvas
    graphics.DrawImage(raster, destRect, srcRect, GraphicsUnit.Pixel);

    // Finalize recording and obtain a WMF image containing the drawing commands
    using (WmfImage wmf = graphics.EndRecording())
    {
        // Prepare BMP save options
        BmpOptions bmpOptions = new BmpOptions();

        // Save the WMF image as a raster BMP file.
        // The WMF will be rasterized automatically according to the BMP options.
        using (FileStream fs = new FileStream(outputPath, FileMode.Create))
        {
            wmf.Save(fs, bmpOptions);
        }
    }
}