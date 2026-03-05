using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the source presentation and the output copy
        string sourcePath = "input.ppt";
        string outputPath = "output.ppt";

        // Configure load options to keep the source locked, reducing memory usage
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions
        {
            BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
            {
                PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked
            }
        };

        // Load the presentation with the specified load options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions);

        // Example operation: rename the first slide
        presentation.Slides[0].Name = "FirstSlide";

        // Save the presentation in PPT format before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Dispose the presentation to release the lock on the source file
        presentation.Dispose();

        // Optionally delete the original source file after processing
        if (File.Exists(sourcePath))
        {
            File.Delete(sourcePath);
        }
    }
}