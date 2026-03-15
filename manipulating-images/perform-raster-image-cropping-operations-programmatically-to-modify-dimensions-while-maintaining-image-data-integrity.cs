using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

// Define the directory containing the source image
string dir = @"c:\temp\";

// ---------------------------------------------------------------------
// Example 1: Crop a raster image using a Rectangle (central area)
// ---------------------------------------------------------------------
using (Image image = Image.Load(dir + "sample.png"))
{
    // Cast to RasterImage to access Width and Height properties
    RasterImage raster = (RasterImage)image;

    // Create a rectangle that represents the central half of the image
    Rectangle centralArea = new Rectangle(
        raster.Width / 4,          // X coordinate (left)
        raster.Height / 4,         // Y coordinate (top)
        raster.Width / 2,          // Width
        raster.Height / 2);        // Height

    // Perform the cropping operation
    raster.Crop(centralArea);

    // Save the cropped image (same format as original)
    raster.Save(dir + "sample.Crop.png");
}

// ---------------------------------------------------------------------
// Example 2: Crop a raster image using shift values (10% margins)
// ---------------------------------------------------------------------
using (Image image = Image.Load(dir + "sample.png"))
{
    RasterImage raster = (RasterImage)image;

    // Calculate 10% of the dimensions to use as margins
    int horizontalMargin = raster.Width / 10;
    int verticalMargin   = raster.Height / 10;

    // Crop by specifying left, right, top, and bottom shifts
    raster.Crop(horizontalMargin, horizontalMargin, verticalMargin, verticalMargin);

    // Save the result
    raster.Save(dir + "sample.CropShift.png");
}