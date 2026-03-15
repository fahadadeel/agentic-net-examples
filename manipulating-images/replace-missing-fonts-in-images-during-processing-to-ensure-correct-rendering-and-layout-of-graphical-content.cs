using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input folder containing WMF/EMF files
        string inputFolder = @"C:\Images";
        // Output folder for rendered PNGs
        string outputFolder = @"C:\Processed";
        Directory.CreateDirectory(outputFolder);

        // Configure Aspose.Imaging to use a known fonts folder (e.g., Windows fonts)
        string systemFonts = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts));
        FontSettings.SetFontsFolder(systemFonts);
        FontSettings.UpdateFonts();

        // Set a default fallback font that will be used when a required font is missing
        FontSettings.DefaultFontName = "Arial";

        // Process each WMF or EMF file in the input folder
        foreach (string filePath in Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly))
        {
            string ext = Path.GetExtension(filePath).ToLowerInvariant();
            if (ext != ".wmf" && ext != ".emf")
                continue; // Skip non‑metafile files

            // Load the metafile using Aspose.Imaging (lifecycle: load)
            using (Image image = Image.Load(filePath))
            {
                // Cast to MetaImage to retrieve font information
                MetaImage meta = image as MetaImage;
                if (meta != null)
                {
                    // Get the list of fonts that were referenced but not found
                    string[] missedFonts = meta.GetMissedFonts();
                    if (missedFonts.Length > 0)
                    {
                        Console.WriteLine($"File: {Path.GetFileName(filePath)} – missing fonts:");
                        foreach (string font in missedFonts)
                            Console.WriteLine($"  {font}");
                    }
                }

                // Render the metafile to a raster format (PNG) after font substitution
                var pngOptions = new PngOptions();
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(filePath) + ".png");

                // Save the rendered image (lifecycle: save)
                image.Save(outputPath, pngOptions);
                Console.WriteLine($"Rendered image saved to: {outputPath}");
            }
        }
    }
}