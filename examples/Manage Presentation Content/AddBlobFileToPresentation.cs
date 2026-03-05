using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the large file (e.g., a video or a high‑resolution image)
        string largeFilePath = "large_video.mp4";

        // Create a new presentation (contains one empty slide by default)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Open the large file as a stream and add it to the presentation as a BLOB
        using (FileStream fileStream = new FileStream(largeFilePath, FileMode.Open, FileAccess.Read))
        {
            // Keep the stream locked inside the presentation to avoid loading the whole file into memory
            Aspose.Slides.IPPImage blobImage = presentation.Images.AddImage(fileStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

            // Insert the BLOB as a picture frame on the first slide
            Aspose.Slides.IShape pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                0, 0, 300, 200,
                blobImage);
        }

        // Save the presentation in PPTX format before exiting
        presentation.Save("PresentationWithLargeFile.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}