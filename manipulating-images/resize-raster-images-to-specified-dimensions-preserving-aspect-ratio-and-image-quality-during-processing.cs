using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 4)
        {
            Console.WriteLine("Usage: <inputPath> <outputPath> <targetWidth> <targetHeight>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        if (!int.TryParse(args[2], out int targetWidth) || targetWidth <= 0 ||
            !int.TryParse(args[3], out int targetHeight) || targetHeight <= 0)
        {
            Console.WriteLine("Invalid target dimensions.");
            return;
        }

        using (Image image = Image.Load(inputPath))
        {
            double widthScale = (double)targetWidth / image.Width;
            double heightScale = (double)targetHeight / image.Height;
            double scale = Math.Min(widthScale, heightScale);

            int newWidth = Math.Max(1, (int)(image.Width * scale));
            int newHeight = Math.Max(1, (int)(image.Height * scale));

            image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            ImageOptionsBase saveOptions;
            string ext = Path.GetExtension(outputPath).ToLowerInvariant();
            switch (ext)
            {
                case ".jpg":
                case ".jpeg":
                    saveOptions = new JpegOptions();
                    break;
                case ".png":
                    saveOptions = new PngOptions();
                    break;
                case ".bmp":
                    saveOptions = new BmpOptions();
                    break;
                case ".tif":
                case ".tiff":
                    saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                    break;
                case ".gif":
                    saveOptions = new GifOptions();
                    break;
                case ".webp":
                    saveOptions = new WebPOptions();
                    break;
                default:
                    saveOptions = new JpegOptions();
                    break;
            }

            image.Save(outputPath, saveOptions);
        }
    }
}