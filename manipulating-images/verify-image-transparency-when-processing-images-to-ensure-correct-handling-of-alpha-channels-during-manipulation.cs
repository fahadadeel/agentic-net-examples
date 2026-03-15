using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> <outputImagePath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            bool hasTransparency = HasTransparency(image);
            Console.WriteLine($"Image '{Path.GetFileName(inputPath)}' has transparency: {hasTransparency}");

            string ext = Path.GetExtension(outputPath).ToUpperInvariant();
            Source fileSource = new FileCreateSource(outputPath, false);

            if (ext == ".PNG")
            {
                var pngOptions = new PngOptions { Source = fileSource };
                image.Save(outputPath, pngOptions);
            }
            else if (ext == ".JPG" || ext == ".JPEG")
            {
                var jpegOptions = new JpegOptions { Source = fileSource, Quality = 100 };
                image.Save(outputPath, jpegOptions);
            }
            else if (ext == ".BMP")
            {
                var bmpOptions = new BmpOptions { Source = fileSource };
                image.Save(outputPath, bmpOptions);
            }
            else if (ext == ".GIF")
            {
                var gifOptions = new GifOptions { Source = fileSource };
                image.Save(outputPath, gifOptions);
            }
            else if (ext == ".TIFF")
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default) { Source = fileSource };
                image.Save(outputPath, tiffOptions);
            }
            else if (ext == ".WEBP")
            {
                var webpOptions = new WebPOptions { Source = fileSource };
                image.Save(outputPath, webpOptions);
            }
            else
            {
                var fallbackOptions = new JpegOptions { Source = fileSource, Quality = 100 };
                image.Save(outputPath, fallbackOptions);
            }
        }
    }

    private static bool HasTransparency(RasterImage img)
    {
        int[] pixels = img.LoadArgb32Pixels(img.Bounds);
        foreach (int pixel in pixels)
        {
            int alpha = (pixel >> 24) & 0xFF;
            if (alpha < 255)
                return true;
        }
        return false;
    }
}