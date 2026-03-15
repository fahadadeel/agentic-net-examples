using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

// Path to the source EMF file
string inputFile = @"C:\Temp\source.emf";

// Desired output SVG file path
string outputFile = @"C:\Temp\converted.svg";

// Load the EMF image using the unified Image.Load method.
// The using statement ensures the image is disposed properly.
using (EmfImage emfImage = (EmfImage)Image.Load(inputFile))
{
    // Create SVG save options.
    SvgOptions svgOptions = new SvgOptions
    {
        // Render all text as vector shapes to preserve appearance.
        TextAsShapes = true
    };

    // Configure rasterization options specific to EMF.
    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
    {
        // Set the background of the drawing surface.
        BackgroundColor = Color.WhiteSmoke,

        // Use the original EMF size as the page size.
        PageSize = emfImage.Size,

        // Automatically choose the appropriate render mode (EMF or WMF).
        RenderMode = EmfRenderMode.Auto,

        // Optional margins; set to zero if not needed.
        BorderX = 0,
        BorderY = 0
    };

    // Attach the rasterization options to the SVG options.
    svgOptions.VectorRasterizationOptions = rasterOptions;

    // Save the EMF image as SVG using the configured options.
    emfImage.Save(outputFile, svgOptions);
}