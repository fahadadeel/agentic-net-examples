using System;
using System.IO;
using Aspose.Slides;

namespace PresentationBlobManagementExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure load options for efficient BLOB handling
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;
            loadOptions.BlobManagementOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;
            loadOptions.BlobManagementOptions.MaxBlobsBytesInMemory = 50 * 1024 * 1024; // 50 MB limit

            // Load an existing presentation with the specified options
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx", loadOptions);

            // Add a large image as a BLOB using KeepLocked behavior
            FileStream imageStream = new FileStream("large_image.jpg", FileMode.Open, FileAccess.Read);
            Aspose.Slides.IPPImage largeImage = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
            imageStream.Close();

            // Insert the image into the first slide
            presentation.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, largeImage);

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}