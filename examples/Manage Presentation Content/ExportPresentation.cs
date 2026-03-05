using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create a memory stream to hold the BLOB data
        MemoryStream blobStream = new MemoryStream();

        // Save the presentation to the stream in PPTX format
        presentation.Save(blobStream, Aspose.Slides.Export.SaveFormat.Pptx);

        // Retrieve the byte array from the stream (optional)
        byte[] blobData = blobStream.ToArray();

        // Example: write the BLOB to a file
        File.WriteAllBytes("output_blob.pptx", blobData);

        // Dispose resources
        presentation.Dispose();
        blobStream.Dispose();
    }
}