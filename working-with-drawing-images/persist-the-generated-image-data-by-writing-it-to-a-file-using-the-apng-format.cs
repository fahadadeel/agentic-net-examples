using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Path to the source image (any supported format)
        string sourcePath = "source.png";

        // Path where the APNG file will be saved
        string outputPath = "result.apng";

        // Load the source image
        using (Image image = Image.Load(sourcePath))
        {
            // Save the image as an APNG file.
            // DefaultFrameTime sets the duration of each frame in milliseconds.
            image.Save(outputPath, new ApngOptions { DefaultFrameTime = 500 });
        }
    }
}