using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Resize and crop a WebP image, then save as JPEG
        string inputWebp = "input.webp";
        string outputJpeg = "output_resized_cropped.jpg";

        using (WebPImage webp = (WebPImage)Image.Load(inputWebp))
        {
            // Resize to half of original dimensions
            webp.Resize(webp.Width / 2, webp.Height / 2);

            // Crop a rectangle leaving a 10‑pixel border
            var cropRect = new Rectangle(10, 10, webp.Width - 20, webp.Height - 20);
            webp.Crop(cropRect);

            // Save with JPEG options
            var jpegOptions = new JpegOptions { Quality = 80 };
            webp.Save(outputJpeg, jpegOptions);
        }

        // Convert a PNG image to TIFF without changing dimensions
        string inputPng = "input.png";
        string outputTiff = "output.tiff";

        using (Image png = Image.Load(inputPng))
        {
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            png.Save(outputTiff, tiffOptions);
        }

        // Resize a GIF image using Lanczos resampling and save as PNG
        string inputGif = "input.gif";
        string outputGifPng = "output_resized.png";

        using (Image gif = Image.Load(inputGif))
        {
            // Double the size with high‑quality Lanczos resampling
            gif.Resize(gif.Width * 2, gif.Height * 2, ResizeType.LanczosResample);

            var pngOptions = new PngOptions();
            gif.Save(outputGifPng, pngOptions);
        }
    }
}