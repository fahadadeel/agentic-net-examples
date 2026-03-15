using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png; // Example format, adjust as needed
using Aspose.Imaging.ImageOptions;

class ImageResizer
{
    // Resizes an image using the specified ResizeType and saves the result.
    // Parameters:
    //   inputPath  - full path to the source image file.
    //   outputPath - full path where the resized image will be saved.
    //   newWidth   - desired width after resizing.
    //   newHeight  - desired height after resizing.
    //   resizeType - the ResizeType enumeration value that defines the scaling algorithm.
    public static void ResizeImage(string inputPath, string outputPath, int newWidth, int newHeight, ResizeType resizeType)
    {
        // Load the image using Aspose.Imaging's factory method.
        using (Image image = Image.Load(inputPath))
        {
            // Perform the resize operation with the chosen ResizeType.
            image.Resize(newWidth, newHeight, resizeType);

            // Determine appropriate save options based on the output file extension.
            // Here we use PngOptions as a generic example; replace with the correct options for your format.
            var saveOptions = new PngOptions();

            // Save the resized image to the specified location.
            image.Save(outputPath, saveOptions);
        }
    }

    // Example usage.
    static void Main()
    {
        string sourceFile = @"C:\Images\sample.png";
        string destinationFile = @"C:\Images\sample_resized.png";

        // Resize to 800x600 using Bilinear resampling.
        ResizeImage(sourceFile, destinationFile, 800, 600, ResizeType.BilinearResample);
    }
}