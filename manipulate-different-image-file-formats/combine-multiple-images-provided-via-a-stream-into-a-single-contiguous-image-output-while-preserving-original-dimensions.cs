using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input image file paths (replace with actual paths or streams as needed)
        string[] inputPaths = new string[]
        {
            "image1.png",
            "image2.png",
            "image3.png"
        };

        // Output image path
        string outputPath = "combined.png";

        // Collect sizes of all images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (FileStream fs = File.OpenRead(path))
            using (RasterImage img = (RasterImage)Image.Load(fs))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal concatenation
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Create output file source and PNG options
        Source outSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = outSource };

        // Create canvas image
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (FileStream fs = File.OpenRead(path))
                using (RasterImage img = (RasterImage)Image.Load(fs))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the combined image (canvas is already bound to the output source)
            canvas.Save();
        }
    }
}