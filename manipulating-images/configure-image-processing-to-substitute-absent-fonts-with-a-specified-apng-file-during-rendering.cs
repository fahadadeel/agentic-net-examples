using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Paths configuration
        string inputPath = @"C:\Images\Input";
        string outputPath = @"C:\Images\Output";
        string vectorFileName = "sample.svg";               // Vector image that may reference missing fonts
        string fontsFolder = @"C:\Fonts";                  // Folder containing fallback fonts
        string placeholderApngPath = Path.Combine(inputPath, "placeholder.apng"); // APNG used as substitution
        string resultFilePath = Path.Combine(outputPath, "result.png");

        // Prepare load options with a custom font source provider
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(GetFontSource, fontsFolder);

        // Load the vector image using the custom font source
        using (Image vectorImage = Image.Load(Path.Combine(inputPath, vectorFileName), loadOptions))
        {
            // Obtain rasterization options for rendering the vector image
            var rasterOptions = (VectorRasterizationOptions)vectorImage.GetDefaultOptions(
                new object[] { Color.White, vectorImage.Width, vectorImage.Height });
            rasterOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            rasterOptions.SmoothingMode = SmoothingMode.None;

            // Render the vector image to a temporary PNG file
            string tempPngPath = Path.Combine(outputPath, "temp_rendered.png");
            vectorImage.Save(tempPngPath, new PngOptions { VectorRasterizationOptions = rasterOptions });

            // Load the rendered raster image
            using (RasterImage renderedImage = (RasterImage)Image.Load(tempPngPath))
            {
                // Load the APNG placeholder (first frame will be used as overlay)
                using (ApngImage placeholderApng = (ApngImage)Image.Load(placeholderApngPath))
                {
                    // Extract the first frame of the APNG as a raster image
                    RasterImage overlay = (RasterImage)placeholderApng.Pages[0];

                    // Blend the overlay onto the rendered image at the desired location (e.g., top‑left corner)
                    renderedImage.Blend(new Point(0, 0), overlay, 255);
                }

                // Save the final image where missing fonts are visually substituted by the APNG overlay
                renderedImage.Save(resultFilePath, new PngOptions());
            }

            // Clean up the temporary file
            if (File.Exists(tempPngPath))
                File.Delete(tempPngPath);
        }
    }

    // Custom font source provider – supplies fonts from a specified directory
    private static CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = args.Length > 0 ? args[0].ToString() : string.Empty;
        var fontDataList = new List<CustomFontHandler.CustomFontData>();

        foreach (string fontFile in Directory.GetFiles(fontsPath))
        {
            string fontName = Path.GetFileNameWithoutExtension(fontFile);
            byte[] fontBytes = File.ReadAllBytes(fontFile);
            fontDataList.Add(new CustomFontHandler.CustomFontData(fontName, fontBytes));
        }

        return fontDataList.ToArray();
    }
}