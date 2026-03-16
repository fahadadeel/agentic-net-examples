using System;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Path to the SVG file to be loaded
        string svgFilePath = @"C:\Images\example.svg";

        // Instantiate the SvgImage object by loading the SVG file from the specified path
        using (SvgImage svgImage = new SvgImage(svgFilePath))
        {
            // The svgImage object is now loaded in memory and ready for further processing
            // Example: access image dimensions
            int width = svgImage.Width;
            int height = svgImage.Height;

            Console.WriteLine($"Loaded SVG image: {svgFilePath}");
            Console.WriteLine($"Dimensions: {width}x{height}");
        }
    }
}