using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ExtractEmbeddedRasterImages
{
    static void Main()
    {
        // Path to the vector file (e.g., CorelDRAW, SVG, etc.)
        string inputFile = "test.cdr";

        // Load the vector image using Aspose.Imaging's generic Image.Load method.
        // The returned object is cast to VectorImage to access vector‑specific members.
        using (Image image = Image.Load(inputFile))
        {
            // Ensure the loaded image is a vector type.
            var vectorImage = image as VectorImage;
            if (vectorImage == null)
            {
                Console.WriteLine("The specified file is not a supported vector image.");
                return;
            }

            // Retrieve all embedded raster images.
            // This uses the VectorImage.GetEmbeddedImages() method as defined in the API.
            EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

            // Export each embedded image while preserving its original pixel format.
            for (int i = 0; i < embeddedImages.Length; i++)
            {
                // Construct an output file name (e.g., image0.png, image1.png, ...).
                string outFile = $"image{i}.png";

                // Each EmbeddedImage implements IDisposable and contains an Image instance.
                using (EmbeddedImage embedded = embeddedImages[i])
                {
                    // Save the raster image using PNG format.
                    // PNGOptions automatically retains the source pixel format.
                    embedded.Image.Save(outFile, new PngOptions());
                }

                Console.WriteLine($"Extracted embedded image saved to: {outFile}");
            }
        }
    }
}