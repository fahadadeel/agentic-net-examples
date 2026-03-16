using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Path to the WMF file
        string wmfFilePath = @"C:\Temp\example.wmf";

        // Load the WMF image using the unified Image.Load method
        // The returned Image instance is cast to WmfImage for WMF‑specific operations
        using (Image image = Image.Load(wmfFilePath))
        {
            // Cast to the concrete WmfImage type
            WmfImage wmfImage = (WmfImage)image;

            // At this point wmfImage can be used for further manipulation,
            // e.g., accessing its properties, records, or using a recorder:
            // var recorder = Aspose.Imaging.FileFormats.Wmf.Graphics.WmfRecorderGraphics2D.FromWmfImage(wmfImage);

            // Example: output basic information
            Console.WriteLine($"Width: {wmfImage.Width}, Height: {wmfImage.Height}");
            Console.WriteLine($"File format: {wmfImage.FileFormat}");
        }
    }
}