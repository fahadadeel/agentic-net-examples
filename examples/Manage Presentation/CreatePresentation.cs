using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation in memory
        Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation();

        // Save the presentation to a memory stream in PPTX format
        MemoryStream memoryStream = new MemoryStream();
        sourcePresentation.Save(memoryStream, SaveFormat.Pptx);
        sourcePresentation.Dispose();

        // Reset the stream position to the beginning for reading
        memoryStream.Position = 0;

        // Load a presentation from the memory stream
        Aspose.Slides.Presentation loadedPresentation = new Aspose.Slides.Presentation(memoryStream);

        // Save the loaded presentation to a file
        loadedPresentation.Save("LoadedPresentation.pptx", SaveFormat.Pptx);
        loadedPresentation.Dispose();

        // Close the memory stream
        memoryStream.Close();
    }
}