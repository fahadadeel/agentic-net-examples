using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Apng;

class RemoveBackgroundAndSaveApng
{
    static void Main()
    {
        // Input SVG (or any vector format supported by Aspose.Imaging)
        string inputPath = @"C:\Images\input.svg";

        // Output APNG file – transparency will be preserved after background removal
        string outputPath = @"C:\Images\output.apng";

        // Load the vector image using the generic Image.Load method (lifecycle rule)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to VectorImage to access vector‑specific functionality
            VectorImage vectorImage = (VectorImage)image;

            // Remove the background – this method is provided by the VectorImage class
            vectorImage.RemoveBackground();

            // Prepare rasterization options for converting the vector image to raster frames
            // (required because APNG is a raster format)
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Use the original vector size; you can change this if scaling is needed
                PageSize = vectorImage.Size
            };

            // Create APNG save options and attach the rasterization settings
            var apngOptions = new ApngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the processed image as an APNG (lifecycle rule – Save with options)
            vectorImage.Save(outputPath, apngOptions);
        }
    }
}