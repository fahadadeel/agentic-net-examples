using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Create a new PNG image with a semi‑transparent gradient
        string gradientOutputPath = "gradient.png";
        Source gradientSource = new FileCreateSource(gradientOutputPath, false);
        PngOptions gradientOptions = new PngOptions()
        {
            Source = gradientSource,
            ColorType = PngColorType.TruecolorWithAlpha,
            BitDepth = 8,
            CompressionLevel = 9,
            Progressive = true
        };

        using (PngImage gradientImage = (PngImage)Image.Create(gradientOptions, 200, 200))
        {
            // Brush that fades from blue (opaque) to transparent
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(gradientImage.Width, gradientImage.Height),
                Color.Blue,
                Color.Transparent);

            Graphics graphics = new Graphics(gradientImage);
            graphics.FillRectangle(gradientBrush, gradientImage.Bounds);

            // Since the image is bound to a file source, just call Save()
            gradientImage.Save();
        }

        // Load an existing PNG, adjust its alpha channel uniformly, and save
        string inputPath = "input.png";
        string modifiedOutputPath = "modified.png";

        using (RasterImage sourceRaster = (RasterImage)Image.Load(inputPath))
        {
            // Load all ARGB pixels
            int[] argbPixels = sourceRaster.LoadArgb32Pixels(sourceRaster.Bounds);

            // Set alpha to 128 (50% transparency) for every pixel
            for (int i = 0; i < argbPixels.Length; i++)
            {
                int rgb = argbPixels[i] & 0x00FFFFFF; // keep RGB
                argbPixels[i] = (128 << 24) | rgb;    // set new alpha
            }

            // Prepare options for the output PNG
            Source modifiedSource = new FileCreateSource(modifiedOutputPath, false);
            PngOptions modifiedOptions = new PngOptions()
            {
                Source = modifiedSource,
                ColorType = PngColorType.TruecolorWithAlpha,
                BitDepth = 8,
                CompressionLevel = 9,
                Progressive = true
            };

            // Create a new PNG canvas and write the modified pixels
            using (PngImage modifiedImage = (PngImage)Image.Create(modifiedOptions, sourceRaster.Width, sourceRaster.Height))
            {
                modifiedImage.SaveArgb32Pixels(modifiedImage.Bounds, argbPixels);
                modifiedImage.Save();
            }
        }
    }
}