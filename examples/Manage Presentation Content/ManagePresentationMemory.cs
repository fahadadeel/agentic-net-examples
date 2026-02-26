using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define source and copy paths
        string sourcePath = "largePresentation.ppt";
        string copyPath = "largePresentation_copy.pptx";

        // Configure load options to keep the source file locked during the presentation lifetime
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions
        {
            BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
            {
                PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked
            }
        };

        // Open the very large presentation with the specified load options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions);

        // Rename the first slide (example of modifying content)
        presentation.Slides[0].Name = "RenamedSlide";

        // Save a copy of the presentation in PPTX format (as demonstrated in the rule)
        presentation.Save(copyPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Additionally, save the presentation in PPT format as required
        string outputPptPath = "largePresentation_out.ppt";
        presentation.Save(outputPptPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Delete the original source file now that it is no longer needed
        System.IO.File.Delete(sourcePath);

        // Release all resources
        presentation.Dispose();
    }
}