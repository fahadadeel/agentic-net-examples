using System;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Path to the SVG file to be loaded
        string svgFilePath = @"C:\Images\example.svg";

        // Load the SVG file into an SvgImage object using the constructor that accepts a file path
        // This initializes the image and makes it ready for further manipulation or rendering
        using (SvgImage svgImage = new SvgImage(svgFilePath))
        {
            // At this point svgImage is loaded and can be used for operations such as rasterization,
            // drawing, resizing, etc.
            Console.WriteLine($"SVG loaded. Width: {svgImage.Width}, Height: {svgImage.Height}");
        }
    }
}