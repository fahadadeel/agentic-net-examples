using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationTempFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation (can be PPTX, PPT, etc.)
            string sourcePath = "input.pptx";

            // Desired output path in PPT format
            string outputPath = "output.ppt";

            // Folder where temporary files will be created during BLOB handling
            string tempFolderPath = @"C:\TempSlides";

            // Configure load options with custom temporary folder
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            // Enable creation of temporary files (required when using a custom folder)
            loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;
            // Set the root path for temporary files
            loadOptions.BlobManagementOptions.TempFilesRootPath = tempFolderPath;

            // Load the presentation using the configured options
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions);

            // Save the presentation in PPT format
            presentation.Save(outputPath, SaveFormat.Ppt);

            // Release resources
            presentation.Dispose();
        }
    }
}