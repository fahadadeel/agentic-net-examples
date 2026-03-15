using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ProgressManagement;

namespace AsposeImagingProgressDemo
{
    // Helper class that encapsulates asynchronous load and save operations with progress reporting
    public static class ImageProcessor
    {
        // Asynchronously loads an image from the specified file path.
        // The progressCallback receives ProgressEventHandlerInfo objects that describe the current stage.
        public static Task<Image> LoadImageAsync(string filePath, Action<ProgressEventHandlerInfo> progressCallback)
        {
            return Task.Run(() =>
            {
                // Configure LoadOptions with the progress event handler
                var loadOptions = new LoadOptions
                {
                    ProgressEventHandler = info => progressCallback?.Invoke(info)
                };

                // Load the image using the configured options
                Image image = Image.Load(filePath, loadOptions);
                return image;
            });
        }

        // Asynchronously saves an image to the specified file path using the provided save options.
        // The progressCallback receives ProgressEventHandlerInfo objects that describe the current stage.
        public static Task SaveImageAsync(Image image, string outputPath, ImageOptionsBase saveOptions, Action<ProgressEventHandlerInfo> progressCallback)
        {
            return Task.Run(() =>
            {
                // Attach the progress handler to the save options
                saveOptions.ProgressEventHandler = info => progressCallback?.Invoke(info);

                // Perform the save operation
                image.Save(outputPath, saveOptions);
            });
        }
    }

    // Example usage of the asynchronous load/save with progress reporting
    class Program
    {
        static async Task Main(string[] args)
        {
            string inputFile = @"C:\Images\sample.png";
            string outputFile = @"C:\Images\sample_converted.psd";

            // Load the image with progress feedback
            Image image = await ImageProcessor.LoadImageAsync(inputFile, info =>
            {
                Console.WriteLine($"Load {info.EventType} : {info.Value}/{info.MaxValue}");
            });

            // Prepare save options (e.g., convert to PSD) and attach a progress handler later
            var psdOptions = new PsdOptions();

            // Save the image with progress feedback
            await ImageProcessor.SaveImageAsync(image, outputFile, psdOptions, info =>
            {
                Console.WriteLine($"Save {info.EventType} : {info.Value}/{info.MaxValue}");
            });

            // Dispose the image when done
            image.Dispose();

            Console.WriteLine("Processing completed.");
        }
    }
}