using System;

namespace ManageLargePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the original large PPT file
            System.String sourcePath = "largePresentation.ppt";
            // Path where the copy will be saved
            System.String copyPath = "largePresentationCopy.ppt";

            // Load options with BLOB management to keep the source file locked during processing
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions
            {
                BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
                {
                    PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked
                }
            };

            // Open the large presentation using the specified load options
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions);

            // Rename the first slide (optional demonstration)
            presentation.Slides[0].Name = "RenamedSlide";

            // Save the presentation in PPT format
            presentation.Save(copyPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Release resources
            presentation.Dispose();

            // Delete the original file now that it is no longer locked
            System.IO.File.Delete(sourcePath);
        }
    }
}