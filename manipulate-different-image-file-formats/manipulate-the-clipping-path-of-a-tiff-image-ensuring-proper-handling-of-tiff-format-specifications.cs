using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output TIFF file paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Load the TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Keep only the first existing clipping path (if any)
            var trimmedPaths = image.ActiveFrame.PathResources.Take(1).ToList();

            // Create a rectangular clipping path using GraphicsPath
            var figure = new Figure();
            // Rectangle at (50,50) with width=200 and height=200
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));

            var graphicsPath = new GraphicsPath();
            graphicsPath.AddFigure(figure);

            // Convert the GraphicsPath to PathResource objects
            IEnumerable<PathResource> newResources = PathResourceConverter.FromGraphicsPath(graphicsPath, image.Size);

            // Combine the retained path with the new rectangular path
            trimmedPaths.AddRange(newResources);
            image.ActiveFrame.PathResources = trimmedPaths;

            // Save the modified TIFF image
            image.Save(outputPath);
        }
    }
}