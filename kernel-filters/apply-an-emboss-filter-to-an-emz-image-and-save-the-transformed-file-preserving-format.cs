using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.FileFormats.Emf.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input EMZ file path
        string inputPath = "input.emz";
        // Output EMZ file path
        string outputPath = "output.emz";

        // Load the EMZ image (vector format)
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare vector rasterization options for converting to raster
            var vectorRasterOptions = (VectorRasterizationOptions)vectorImage.GetDefaultOptions(new object[] { Color.White, vectorImage.Width, vectorImage.Height });

            // Rasterize the vector image to a PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions { VectorRasterizationOptions = vectorRasterOptions };
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    // Apply Emboss filter using convolution kernel
                    rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Create a new EMF canvas with the same dimensions
                    using (EmfImage emfCanvas = new EmfImage(rasterImage.Width, rasterImage.Height))
                    {
                        // Obtain graphics recorder for drawing
                        EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfCanvas);

                        // Draw the filtered raster image onto the EMF canvas
                        graphics.DrawImage(rasterImage, new Rectangle(0, 0, rasterImage.Width, rasterImage.Height));

                        // Finalize recording to obtain the resulting EMF image
                        using (EmfImage resultEmf = graphics.EndRecording())
                        {
                            // Save the result as compressed EMZ (EMF with compression)
                            var emfSaveOptions = new EmfOptions { Compress = true };
                            resultEmf.Save(outputPath, emfSaveOptions);
                        }
                    }
                }
            }
        }
    }
}