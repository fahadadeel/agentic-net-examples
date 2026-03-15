using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.png";
        string fontFolder = "fonts";

        var loadOptions = new Aspose.Imaging.LoadOptions();
        loadOptions.AddCustomFontSource(GetFontSource, fontFolder);

        using (var image = Aspose.Imaging.Image.Load(inputPath, loadOptions))
        {
            Aspose.Imaging.FontSettings.DefaultFontName = "Arial";

            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = Aspose.Imaging.SmoothingMode.None
            };

            var pngOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };
            image.Save(outputPath, pngOptions);
        }
    }

    private static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = args.Length > 0 ? args[0]?.ToString() ?? string.Empty : string.Empty;
        var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();

        if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
        {
            foreach (var file in Directory.GetFiles(fontsPath))
            {
                string fontName = Path.GetFileNameWithoutExtension(file);
                byte[] fontData = File.ReadAllBytes(file);
                fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontData));
            }
        }

        return fonts.ToArray();
    }
}