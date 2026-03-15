using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.bigtiff";

        using (Image loadedImage = Image.Load(inputPath))
        {
            TiffImage tiffImage = loadedImage as TiffImage;
            if (tiffImage == null)
            {
                Console.WriteLine("The input file is not a TIFF image.");
                return;
            }

            if (!tiffImage.IsCached)
                tiffImage.CacheData();

            TiffFrame copiedFrame = TiffFrame.CopyFrame(tiffImage.ActiveFrame);

            using (BigTiffImage bigTiff = new BigTiffImage(copiedFrame))
            {
                bigTiff.AdjustBrightness(20);
                bigTiff.Rotate(45f);
                bigTiff.Crop(new Rectangle(50, 50, 200, 200));

                using (BigTiffOptions saveOptions = new BigTiffOptions(TiffExpectedFormat.Default))
                {
                    saveOptions.Compression = TiffCompressions.AdobeDeflate;
                    saveOptions.Photometric = TiffPhotometrics.Rgb;
                    saveOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                    saveOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                    bigTiff.Save(outputPath, saveOptions);
                }
            }
        }

        Console.WriteLine("BigTIFF processing completed.");
    }
}