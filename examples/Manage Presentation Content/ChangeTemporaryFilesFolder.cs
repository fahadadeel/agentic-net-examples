using System;

class Program
{
    static void Main()
    {
        // Set a custom folder for temporary files used by Aspose.Slides
        Aspose.Slides.BlobManagementOptions blobOptions = new Aspose.Slides.BlobManagementOptions();
        blobOptions.TempFilesRootPath = "C:\\MyTempFolder";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Save the presentation in PPTX format
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}