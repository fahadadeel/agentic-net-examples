using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageProcessingDemo
{
    public static class StaticImageProcessor
    {
        /// <summary>
        /// Loads an image, ensures it contains only a single frame/page,
        /// applies a simple grayscale conversion, and saves the result.
        /// </summary>
        /// <param name="inputPath">Full path to the source image file.</param>
        /// <param name="outputPath">Full path where the processed image will be saved.</param>
        public static void ProcessSingleFrameImage(string inputPath, string outputPath)
        {
            // Load the image using Aspose.Imaging's built‑in load method.
            // This follows the required lifecycle rule: create → load → save.
            using (Image image = Image.Load(inputPath))
            {
                // Determine if the image is a multi‑page/frame type.
                // Most raster formats expose a Frames or Pages collection.
                // If the collection exists and contains more than one element,
                // we consider it a multi‑frame image and skip processing.
                bool isMultiFrame = false;

                // TiffImage, GifImage, WebpImage, etc. implement IMultipageImageExt.
                // The Pages property returns an array of RasterImage objects.
                if (image is Aspose.Imaging.FileFormats.Tiff.TiffImage tiffImg)
                {
                    isMultiFrame = tiffImg.Frames.Length > 1;
                }
                else if (image is Aspose.Imaging.FileFormats.Gif.GifImage gifImg)
                {
                    isMultiFrame = gifImg.Frames.Length > 1;
                }
                else if (image is Aspose.Imaging.FileFormats.Webp.WebpImage webpImg)
                {
                    isMultiFrame = webpImg.Frames.Length > 1;
                }
                else if (image is Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImg)
                {
                    isMultiFrame = dicomImg.Pages.Count > 1;
                }
                // Add other formats as needed following the same pattern.

                // If the image has more than one frame, we do not process it.
                if (isMultiFrame)
                {
                    throw new InvalidOperationException("The provided image contains multiple frames. This method only processes single‑frame images.");
                }

                // Apply a simple operation – convert the image to grayscale.
                // The Grayscale method is part of the Aspose.Imaging API and works for raster images.
                image.Grayscale();

                // Save the processed image using the same format as the source.
                // The Save(string) overload follows the required lifecycle rule.
                image.Save(outputPath);
            }
        }

        // Example usage:
        // StaticImageProcessor.ProcessSingleFrameImage(@"C:\Images\photo.jpg", @"C:\Images\photo_gray.jpg");
    }
}