using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the original large presentation
        System.String sourcePath = "largePresentation.pptx";
        // Path where the copy will be saved
        System.String copyPath = "largePresentation_copy.pptx";

        // Load options with BLOB management to keep the source locked
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions
        {
            BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
            {
                PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked
            }
        };

        // Open the large presentation using the load options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions);

        // Rename the first slide (example operation)
        presentation.Slides[0].Name = "RenamedSlide";

        // Save the presentation copy in PPTX format
        presentation.Save(copyPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation to release resources and unlock the source file
        presentation.Dispose();

        // Delete the original large file
        System.IO.File.Delete(sourcePath);
    }
}