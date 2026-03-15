using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source raster image
        string inputPath = "input.png";

        // Verify that the source file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Source file not found: {inputPath}");
            return;
        }

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Convert to JPEG with maximum quality to preserve fidelity
            string jpegPath = "output.jpg";
            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.Quality = 100; // highest quality
                image.Save(jpegPath, jpegOptions);
            }

            // Convert to PNG (lossless format)
            string pngPath = "output.png";
            using (PngOptions pngOptions = new PngOptions())
            {
                image.Save(pngPath, pngOptions);
            }

            // Convert to BMP (uncompressed truecolor)
            string bmpPath = "output.bmp";
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.BitsPerPixel = 24;
                image.Save(bmpPath, bmpOptions);
            }

            // Convert to TIFF (default compression)
            string tiffPath = "output.tif";
            using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                image.Save(tiffPath, tiffOptions);
            }

            // Convert to GIF (palette based)
            string gifPath = "output.gif";
            using (GifOptions gifOptions = new GifOptions())
            {
                image.Save(gifPath, gifOptions);
            }

            // Convert to WebP (lossless)
            string webpPath = "output.webp";
            using (WebPOptions webpOptions = new WebPOptions())
            {
                webpOptions.Lossless = true;
                image.Save(webpPath, webpOptions);
            }
        }

        Console.WriteLine("All conversions completed successfully.");
    }
}