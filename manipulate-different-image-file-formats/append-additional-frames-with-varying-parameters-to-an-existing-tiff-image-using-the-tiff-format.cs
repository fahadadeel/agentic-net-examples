using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // First additional frame
            TiffOptions frameOptions1 = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 8, 8, 8 },
                Photometric = TiffPhotometrics.Rgb,
                Compression = TiffCompressions.Lzw,
                ByteOrder = TiffByteOrder.BigEndian,
                PlanarConfiguration = TiffPlanarConfigs.Contiguous
            };

            TiffFrame frame1 = new TiffFrame(frameOptions1, 200, 200);

            LinearGradientBrush gradient1 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame1.Width, frame1.Height),
                Color.Blue,
                Color.Yellow);

            Graphics graphics1 = new Graphics(frame1);
            graphics1.FillRectangle(gradient1, frame1.Bounds);

            tiffImage.AddFrame(frame1);

            // Second additional frame
            TiffOptions frameOptions2 = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 1 },
                Photometric = TiffPhotometrics.MinIsBlack,
                Compression = TiffCompressions.CcittFax3,
                ByteOrder = TiffByteOrder.LittleEndian,
                PlanarConfiguration = TiffPlanarConfigs.Contiguous
            };

            TiffFrame frame2 = new TiffFrame(frameOptions2, 150, 150);

            LinearGradientBrush gradient2 = new LinearGradientBrush(
                new Point(0, 0),
                new Point(frame2.Width, frame2.Height),
                Color.Blue,
                Color.Yellow);

            Graphics graphics2 = new Graphics(frame2);
            graphics2.FillRectangle(gradient2, frame2.Bounds);

            tiffImage.AddFrame(frame2);

            tiffImage.Save(outputPath);
        }
    }
}