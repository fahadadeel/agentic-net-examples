using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths
        string sourcePath = "input.pptx";
        string imagePath = "large_image.jpg";
        string outputPath = "output.pptx";

        // Configure BLOB management options
        Aspose.Slides.BlobManagementOptions blobOptions = new Aspose.Slides.BlobManagementOptions();
        blobOptions.IsTemporaryFilesAllowed = true;
        blobOptions.MaxBlobsBytesInMemory = 10 * 1024 * 1024; // 10 MB
        blobOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;

        // Load options with BLOB settings
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.BlobManagementOptions = blobOptions;

        // Load presentation with the specified options
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath, loadOptions))
        {
            // Add a large image as a BLOB using KeepLocked behavior
            using (FileStream imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage img = pres.Images.AddImage(imgStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                // Insert picture frame on the first slide
                pres.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}