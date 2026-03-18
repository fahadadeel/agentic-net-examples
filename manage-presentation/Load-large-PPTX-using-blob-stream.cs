using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LargePresentationLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Configure load options with BLOB management for efficient memory usage
                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.BlobManagementOptions = new Aspose.Slides.BlobManagementOptions();
                loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;
                loadOptions.BlobManagementOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;
                // Optional: limit memory usage for BLOBs (e.g., 50 MB)
                loadOptions.BlobManagementOptions.MaxBlobsBytesInMemory = 50 * 1024 * 1024;

                // Path to the large presentation file
                string inputPath = "largePresentation.pptx";

                // Load the presentation with the specified options
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

                // Example operation: output the number of slides
                int slideCount = presentation.Slides.Count;
                Console.WriteLine($"Loaded presentation with {slideCount} slides.");

                // Save the presentation before exiting
                string outputPath = "outputPresentation.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}