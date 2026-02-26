using System;

class Program
{
    static void Main(string[] args)
    {
        // Set the folder for temporary files
        Aspose.Slides.BlobManagementOptions blobOptions = new Aspose.Slides.BlobManagementOptions();
        blobOptions.TempFilesRootPath = "C:\\TempAsposeSlides";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide (presentation has one empty slide by default)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Save the presentation in PPT format
        presentation.Save("output.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
    }
}