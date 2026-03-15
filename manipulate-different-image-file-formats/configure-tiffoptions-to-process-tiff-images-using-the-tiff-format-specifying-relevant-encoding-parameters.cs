using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.tif";

        // Configure TIFF encoding options
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.ByteOrder = TiffByteOrder.BigEndian;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        tiffOptions.Predictor = TiffPredictor.Horizontal;
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create a TIFF image with the specified options
        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 200, 200))
        {
            // Fill the image with a blue‑yellow gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(tiffImage.Width, tiffImage.Height),
                Color.Blue,
                Color.Yellow))
            {
                Graphics graphics = new Graphics(tiffImage.ActiveFrame);
                graphics.FillRectangle(brush, tiffImage.Bounds);
            }

            // Save the image (file is already bound by the source)
            tiffImage.Save();
        }
    }
}