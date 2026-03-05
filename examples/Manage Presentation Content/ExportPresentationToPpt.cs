using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file
        string sourcePath = "input.pptx";

        // Path to the output PPT file
        string outputPath = "output.ppt";

        // Load the presentation from the source file
        Presentation presentation = new Presentation(sourcePath);

        // Create a memory stream to act as a BLOB container
        using (MemoryStream blobStream = new MemoryStream())
        {
            // Save the presentation into the memory stream in PPT format
            presentation.Save(blobStream, SaveFormat.Ppt);

            // Reset the stream position to the beginning before reading
            blobStream.Position = 0;

            // Write the BLOB data to the output file
            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                blobStream.CopyTo(fileStream);
            }
        }

        // Dispose the presentation to release resources
        presentation.Dispose();
    }
}