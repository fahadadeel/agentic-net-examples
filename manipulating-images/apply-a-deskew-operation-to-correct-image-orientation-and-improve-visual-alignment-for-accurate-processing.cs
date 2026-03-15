using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

// Input and output file paths
string inputFilePath = @"C:\Images\skewed.png";
string outputFilePath = @"C:\Images\deskewed.png";

// Load the image as a RasterImage (covers PNG, JPEG, TIFF, etc.)
using (RasterImage image = (RasterImage)Image.Load(inputFilePath))
{
    // Deskew the image.
    // Parameters:
    //   resizeProportionally = false  -> keep original canvas size
    //   backgroundColor = Color.LightGray -> fill empty areas after rotation
    image.NormalizeAngle(false, Color.LightGray);

    // Save the corrected image
    image.Save(outputFilePath);
}