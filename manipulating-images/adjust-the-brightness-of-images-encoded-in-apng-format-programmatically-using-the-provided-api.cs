using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

namespace ApngBrightnessAdjustment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example usage:
            // Adjust the brightness of an APNG image and save the result.
            string inputPath = "input.apng";
            string outputPath = "output.apng";
            int brightness = 30; // Increase brightness by 30 (range depends on implementation)

            AdjustApngBrightness(inputPath, outputPath, brightness);
        }

        /// <summary>
        /// Loads an APNG image, adjusts its brightness, and saves the modified image.
        /// </summary>
        /// <param name="inputFile">Path to the source APNG file.</param>
        /// <param name="outputFile">Path where the adjusted APNG will be saved.</param>
        /// <param name="brightness">Brightness value to apply (positive to brighten, negative to darken).</param>
        static void AdjustApngBrightness(string inputFile, string outputFile, int brightness)
        {
            // Load the APNG image using Aspose.Imaging's Image.Load method.
            // The returned Image is cast to ApngImage to access APNG-specific members.
            using (ApngImage apng = (ApngImage)Image.Load(inputFile))
            {
                // Adjust the overall brightness of the image.
                // This method modifies all frames uniformly.
                apng.AdjustBrightness(brightness);

                // Save the modified image back to disk.
                // The overload Save(string) writes the image in its original format (APNG).
                apng.Save(outputFile);
            }
        }
    }
}