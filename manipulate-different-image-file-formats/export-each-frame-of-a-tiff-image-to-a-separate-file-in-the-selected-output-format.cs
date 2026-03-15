using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // args[0] - input TIFF file path
        // args[1] - output directory
        // args[2] - desired output format (png, jpg, bmp, gif, webp, tiff)
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <input.tif> <output_folder> <format>");
            return;
        }

        string inputPath = args[0];
        string outputDir = args[1];
        string format = args[2].ToLower();

        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Load the multi‑frame TIFF image
        using (Image image = Image.Load(inputPath))
        {
            TiffImage tiffImage = (TiffImage)image;
            int index = 0;

            foreach (TiffFrame frame in tiffImage.Frames)
            {
                // Choose the appropriate save options based on the requested format
                ImageOptionsBase options;
                string extension;

                switch (format)
                {
                    case "png":
                        options = new PngOptions();
                        extension = "png";
                        break;
                    case "jpg":
                    case "jpeg":
                        options = new JpegOptions();
                        extension = "jpg";
                        break;
                    case "bmp":
                        options = new BmpOptions();
                        extension = "bmp";
                        break;
                    case "gif":
                        options = new GifOptions();
                        extension = "gif";
                        break;
                    case "webp":
                        options = new WebPOptions();
                        extension = "webp";
                        break;
                    case "tif":
                    case "tiff":
                        options = new TiffOptions(TiffExpectedFormat.Default);
                        extension = "tif";
                        break;
                    default:
                        throw new NotSupportedException($"Format '{format}' is not supported.");
                }

                string outputPath = Path.Combine(outputDir, $"frame_{index}.{extension}");

                // Save the current frame using the selected options
                frame.Save(outputPath, options);
                index++;
            }
        }
    }
}