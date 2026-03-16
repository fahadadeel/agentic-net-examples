using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;

string sourcePath = @"C:\Images\sample.wmf";

// Load the WMF image using the unified Image.Load method
using (WmfImage wmfImage = (WmfImage)Image.Load(sourcePath))
{
    // Cache the image data so that all records are available for processing
    wmfImage.CacheData();

    // Obtain a recorder instance for the loaded WMF image (optional, for further manipulation)
    WmfRecorderGraphics2D recorder = WmfRecorderGraphics2D.FromWmfImage(wmfImage);

    // At this point 'wmfImage' and 'recorder' are ready for further processing
}