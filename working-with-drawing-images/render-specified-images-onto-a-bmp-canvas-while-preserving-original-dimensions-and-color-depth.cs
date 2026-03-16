using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input image file paths (replace with actual paths)
            string[] imagePaths = new string[]
            {
                "image1.png",
                "image2.jpg",
                "image3.bmp"
            };

            // Collect sizes and bits-per-pixel of all images
            List<Size> sizes = new List<Size>();
            List<int> bpps = new List<int>();
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                    bpps.Add(img.BitsPerPixel);
                }
            }

            // Calculate canvas dimensions (horizontal layout)
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);
            int maxBitsPerPixel = bpps.Max();

            // Create BMP canvas with appropriate options
            Source source = new FileCreateSource("output.bmp", false);
            BmpOptions bmpOptions = new BmpOptions()
            {
                Source = source,
                BitsPerPixel = maxBitsPerPixel
            };

            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string path in imagePaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound BMP image
                canvas.Save();
            }
        }
    }
}