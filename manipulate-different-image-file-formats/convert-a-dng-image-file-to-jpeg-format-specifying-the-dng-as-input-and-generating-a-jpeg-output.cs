using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;

class DngToJpegConverter
{
    static void Main()
    {
        // Path to the folder containing the DNG file
        string dir = @"C:\temp\";

        // Load the DNG image using the generic Image.Load method
        using (Image image = Image.Load(dir + "input.dng"))
        {
            // Cast the loaded image to DngImage to access DNG‑specific functionality
            DngImage dngImage = (DngImage)image;

            // Define JPEG save options (default options are sufficient for a basic conversion)
            JpegOptions jpegOptions = new JpegOptions();

            // Save the image as JPEG to the desired output path
            dngImage.Save(dir + "output.jpg", jpegOptions);
        }
    }
}