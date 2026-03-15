using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class EmfToVectorConverter
{
    /// <summary>
    /// Converts an EMF metafile to an SVG image while rendering all text as vector shapes.
    /// </summary>
    /// <param name="inputEmfPath">Full path to the source EMF file.</param>
    /// <param name="outputSvgPath">Full path where the resulting SVG will be saved.</param>
    public static void ConvertEmfToSvg(string inputEmfPath, string outputSvgPath)
    {
        // Load the EMF image using the unified Image.Load method.
        using (EmfImage emfImage = (EmfImage)Image.Load(inputEmfPath))
        {
            // Prepare SVG save options.
            SvgOptions svgOptions = new SvgOptions
            {
                // Ensure that all text elements are converted to vector shapes.
                TextAsShapes = true
            };

            // Configure rasterization options for the EMF source.
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                // Use the original EMF size as the page size.
                PageSize = emfImage.Size,

                // Optional: set a background color (transparent by default).
                BackgroundColor = Color.Transparent,

                // Render mode set to Auto to handle embedded EMF/WMF correctly.
                RenderMode = EmfRenderMode.Auto
            };

            // Attach rasterization options to the SVG options.
            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the EMF as an SVG file with the specified options.
            emfImage.Save(outputSvgPath, svgOptions);
        }
    }

    // Example usage.
    static void Main()
    {
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_converted.svg";

        ConvertEmfToSvg(inputPath, outputPath);

        Console.WriteLine("Conversion completed.");
    }
}