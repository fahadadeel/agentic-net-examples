using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class DeconvolutionApngExample
{
    static void Main()
    {
        // Input raster image path
        const string inputPath = "input.png";
        // Output APNG file path
        const string outputPath = "output.apng";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access APNG-specific members
            ApngImage apngImage = (ApngImage)image;

            // Define a simple sharpening kernel for the deconvolution filter
            double[] kernel = new double[]
            {
                -1, -1, -1,
                -1,  9, -1,
                -1, -1, -1
            };

            // Create deconvolution filter options with the kernel
            DeconvolutionFilterOptions deconvOptions = new DeconvolutionFilterOptions(kernel)
            {
                // Optional: adjust brightness and signal‑to‑noise ratio
                Brightness = 1.15f,
                Snr = 0.007f
            };

            // Apply the filter to the whole image rectangle
            Rectangle fullRect = new Rectangle(0, 0, apngImage.Width, apngImage.Height);
            apngImage.Filter(fullRect, deconvOptions);

            // Save the processed image as an animated PNG (APNG)
            ApngOptions apngOptions = new ApngOptions();
            apngImage.Save(outputPath, apngOptions);
        }
    }
}