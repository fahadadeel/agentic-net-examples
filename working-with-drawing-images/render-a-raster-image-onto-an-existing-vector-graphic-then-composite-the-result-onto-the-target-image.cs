using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Input file paths
        string rasterPath = "raster.png";          // Raster image to render onto vector graphic
        string vectorPath = "vector.svg";          // Existing vector graphic
        string targetPath = "target.png";          // Target image onto which the result will be composited
        string outputPath = "output.png";          // Final composited image
        string tempVectorRasterPath = "temp_vector_raster.png"; // Temporary rasterized vector

        // Rasterize the vector graphic to a temporary PNG
        using (SvgImage vectorImg = (SvgImage)Image.Load(vectorPath))
        {
            PngOptions pngOptions = new PngOptions();
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();
            rasterizationOptions.PageSize = vectorImg.Size; // Preserve original size
            pngOptions.VectorRasterizationOptions = rasterizationOptions;

            vectorImg.Save(tempVectorRasterPath, pngOptions);
        }

        // Load images for processing
        using (RasterImage rasterImg = (RasterImage)Image.Load(rasterPath))
        using (RasterImage vectorRasterImg = (RasterImage)Image.Load(tempVectorRasterPath))
        using (RasterImage targetImg = (RasterImage)Image.Load(targetPath))
        {
            // Overlay the raster image onto the rasterized vector graphic at (0,0)
            int overlayPosX = 0;
            int overlayPosY = 0;
            Rectangle overlayBounds = new Rectangle(overlayPosX, overlayPosY, rasterImg.Width, rasterImg.Height);
            vectorRasterImg.SaveArgb32Pixels(overlayBounds, rasterImg.LoadArgb32Pixels(rasterImg.Bounds));

            // Composite the combined vector raster onto the target image at (50,50)
            int targetPosX = 50;
            int targetPosY = 50;
            Rectangle targetBounds = new Rectangle(targetPosX, targetPosY, vectorRasterImg.Width, vectorRasterImg.Height);
            targetImg.SaveArgb32Pixels(targetBounds, vectorRasterImg.LoadArgb32Pixels(vectorRasterImg.Bounds));

            // Save the final composited image
            targetImg.Save(outputPath);
        }

        // Clean up temporary file
        if (File.Exists(tempVectorRasterPath))
        {
            File.Delete(tempVectorRasterPath);
        }
    }
}