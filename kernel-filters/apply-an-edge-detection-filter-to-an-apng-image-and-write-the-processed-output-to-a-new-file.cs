using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        // Input APNG file path
        string inputPath = "input.apng";
        // Output APNG file path
        string outputPath = "output.apng";

        // Load the APNG image
        using (Aspose.Imaging.FileFormats.Apng.ApngImage apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)Image.Load(inputPath))
        {
            // Iterate over each frame in the animation
            foreach (Aspose.Imaging.FileFormats.Apng.ApngFrame frame in apng.Pages)
            {
                // Sobel edge detection kernel (horizontal)
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                // Create convolution filter options with the kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire frame
                frame.Filter(frame.Bounds, filterOptions);
            }

            // Prepare save options for APNG output
            var saveOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the processed APNG image
            apng.Save(outputPath, saveOptions);
        }
    }
}