using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Create a memory stream to hold the PPTX data
        System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();

        // Save the presentation to the memory stream in PPTX format
        presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pptx);

        // Reset the stream position if you need to read from it later
        memoryStream.Position = 0;

        // Dispose resources
        presentation.Dispose();
        memoryStream.Dispose();
    }
}