using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define paths
        string outputFolder = @"C:\Temp\";
        string rasterPath = System.IO.Path.Combine(outputFolder, "sample.jpg");
        string svgOutputPath = System.IO.Path.Combine(outputFolder, "result.svg");

        // Canvas size and resolution
        int canvasWidth = 800;
        int canvasHeight = 600;
        int dpi = 96;

        // Create an SVG graphics context
        SvgGraphics2D graphics = new SvgGraphics2D(canvasWidth, canvasHeight, dpi);

        // Load the raster image to be drawn
        using (RasterImage rasterImage = (RasterImage)Image.Load(rasterPath))
        {
            // Define where the image will be placed on the SVG canvas
            Aspose.Imaging.Point origin = new Aspose.Imaging.Point(100, 50);

            // Define the desired size (scaling) of the raster image
            Aspose.Imaging.Size targetSize = new Aspose.Imaging.Size(300, 200);

            // Draw the raster image onto the SVG canvas with scaling
            graphics.DrawImage(rasterImage, origin, targetSize);
        }

        // Finalize the SVG image and obtain the SvgImage object
        using (SvgImage svgImage = graphics.EndRecording())
        {
            // Save the SVG file
            svgImage.Save(svgOutputPath);
        }

        Console.WriteLine("SVG image created successfully at: " + svgOutputPath);
    }
}