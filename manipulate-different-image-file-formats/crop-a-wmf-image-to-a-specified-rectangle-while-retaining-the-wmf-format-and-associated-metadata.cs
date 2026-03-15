using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path
        string inputPath = "input.wmf";
        // Output WMF file path (cropped image)
        string outputPath = "output.wmf";

        // Define the rectangle to crop: (x, y, width, height)
        int cropX = 50;
        int cropY = 50;
        int cropWidth = 200;
        int cropHeight = 150;

        // Load the WMF image and cast to WmfImage
        using (Aspose.Imaging.FileFormats.Wmf.WmfImage wmfImage = 
               (Aspose.Imaging.FileFormats.Wmf.WmfImage)Image.Load(inputPath))
        {
            // Perform cropping using the specified rectangle
            wmfImage.Crop(new Rectangle(cropX, cropY, cropWidth, cropHeight));

            // Save the cropped image back to WMF format, preserving metadata
            wmfImage.Save(outputPath);
        }
    }
}