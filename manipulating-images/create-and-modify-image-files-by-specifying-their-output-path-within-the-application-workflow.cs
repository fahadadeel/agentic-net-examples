using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input image files to be merged
        string[] inputFiles = new string[]
        {
            "input1.png",
            "input2.png"
        };

        // Output merged image path
        string outputFile = "merged_output.png";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create a bound PNG canvas with a FileCreateSource
        Source source = new FileCreateSource(outputFile, false);
        PngOptions pngOptions = new PngOptions { Source = source };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            // Merge each image onto the canvas
            int offsetX = 0;
            foreach (string path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound image (no need to pass path again)
            canvas.Save();
        }
    }
}