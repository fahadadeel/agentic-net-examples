using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input CDR file path
        string inputCdrPath = @"C:\Images\sample.cdr";

        // Output PNG file path
        string outputPngPath = @"C:\Images\sample.png";

        // Load the CDR document
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputCdrPath))
        {
            // Cache the whole document to avoid repeated I/O
            cdrImage.CacheData();

            // Get the first page (adjust index if you need a different page)
            CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

            // Cache the page data for faster processing
            page.CacheData();

            // Configure PNG save options with rasterization settings to keep visual fidelity
            PngOptions pngOptions = new PngOptions
            {
                // Rasterize the vector page using its original dimensions
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    PageWidth = page.Width,
                    PageHeight = page.Height,
                    // Optional: set smoothing mode, text rendering hint, etc., to match the source
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                }
            };

            // Save the page as a PNG image
            page.Save(outputPngPath, pngOptions);
        }
    }
}