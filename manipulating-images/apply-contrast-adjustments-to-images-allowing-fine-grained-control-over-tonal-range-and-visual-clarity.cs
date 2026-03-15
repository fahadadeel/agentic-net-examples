using System;

namespace ContrastAdjustmentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "sample.png";
            string outputPath = "sample_contrast.png";

            // Contrast value (range: -100 to 100)
            float contrast = 40f;

            // Load the image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage to access AdjustContrast
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Apply contrast adjustment
                raster.AdjustContrast(contrast);

                // Save the adjusted image
                raster.Save(outputPath);
            }
        }
    }
}