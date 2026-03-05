using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        // Output presentation path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Create load options to control external resources (delete embedded binaries)
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.DeleteEmbeddedBinaryObjects = true;

        // Load the presentation with the specified load options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}