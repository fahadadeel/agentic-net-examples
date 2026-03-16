using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Path to the WMF file to be instantiated
        string wmfFilePath = @"C:\Images\sample.wmf";

        // Load the WMF file using Aspose.Imaging's unified loader
        using (Image image = Image.Load(wmfFilePath))
        {
            // Cast the generic Image to a WmfImage for WMF‑specific operations
            WmfImage wmfImage = image as WmfImage;
            if (wmfImage == null)
            {
                throw new InvalidOperationException("The loaded file is not a WMF image.");
            }

            // Example: retrieve basic properties for further processing
            int width = wmfImage.Width;
            int height = wmfImage.Height;

            // Additional WMF processing can be performed here using wmfImage
        }
    }
}