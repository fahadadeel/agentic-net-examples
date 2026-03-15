using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.webp";
        string outputPath = "output.webp";

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WebPImage for filter support
            Aspose.Imaging.FileFormats.Webp.WebPImage webpImage = (Aspose.Imaging.FileFormats.Webp.WebPImage)image;

            // Define an edge detection kernel (Laplacian)
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Create convolution filter options with the kernel
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

            // Apply the edge detection filter to the entire image
            webpImage.Filter(webpImage.Bounds, filterOptions);

            // Save the processed image as WebP
            webpImage.Save(outputPath, new WebPOptions());
        }
    }
}