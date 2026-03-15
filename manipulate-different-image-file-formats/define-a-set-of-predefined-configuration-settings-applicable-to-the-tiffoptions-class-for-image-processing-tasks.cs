using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

namespace TiffOptionsPresets
{
    class Program
    {
        static void Main(string[] args)
        {
            // Preset 1: Default RGB with LZW compression, BigEndian, 8 bits per sample
            var defaultRgb = new TiffOptions(TiffExpectedFormat.Default);
            defaultRgb.BitsPerSample = new ushort[] { 8, 8, 8 };
            defaultRgb.ByteOrder = TiffByteOrder.BigEndian;
            defaultRgb.Compression = TiffCompressions.Lzw;
            defaultRgb.Photometric = TiffPhotometrics.Rgb;
            defaultRgb.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
            defaultRgb.Predictor = TiffPredictor.Horizontal; // optional for LZW

            // Preset 2: Black & White (1-bit) with CCITT Group 3 Fax compression, LittleEndian
            var bwCcitt = new TiffOptions(TiffExpectedFormat.Default);
            bwCcitt.BitsPerSample = new ushort[] { 1 };
            bwCcitt.ByteOrder = TiffByteOrder.LittleEndian;
            bwCcitt.Compression = TiffCompressions.CcittFax3;
            bwCcitt.Photometric = TiffPhotometrics.MinIsBlack;
            bwCcitt.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Preset 3: JPEG compressed RGB image
            var jpegRgb = new TiffOptions(TiffExpectedFormat.Default);
            jpegRgb.BitsPerSample = new ushort[] { 8, 8, 8 };
            jpegRgb.Compression = TiffCompressions.Jpeg;
            jpegRgb.Photometric = TiffPhotometrics.Ycbcr;
            jpegRgb.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
            jpegRgb.YCbCrSubsampling = new ushort[] { 2, 2 };
            jpegRgb.CompressedQuality = 90; // quality for JPEG

            // Preset 4: Deflate compressed RGB image with resolution settings
            var deflateRgb = new TiffOptions(TiffExpectedFormat.Default);
            deflateRgb.BitsPerSample = new ushort[] { 8, 8, 8 };
            deflateRgb.Compression = TiffCompressions.Deflate;
            deflateRgb.Photometric = TiffPhotometrics.Rgb;
            deflateRgb.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
            deflateRgb.ResolutionUnit = TiffResolutionUnits.Inch;
            deflateRgb.Xresolution = new TiffRational(300, 1);
            deflateRgb.Yresolution = new TiffRational(300, 1);

            // Output summary of presets
            Console.WriteLine("Created 4 TiffOptions presets:");
            Console.WriteLine($"1. Default RGB LZW, ByteOrder: {defaultRgb.ByteOrder}");
            Console.WriteLine($"2. B/W CCITT Fax3, ByteOrder: {bwCcitt.ByteOrder}");
            Console.WriteLine($"3. JPEG RGB, Quality: {jpegRgb.CompressedQuality}");
            Console.WriteLine("4. Deflate RGB, Resolution: 300 DPI");
        }
    }
}