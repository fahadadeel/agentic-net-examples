using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Add a custom tag to the presentation
        Aspose.Slides.ITagCollection tags = presentation.CustomData.Tags;
        tags["MyTag"] = "My Tag Value";

        // Save the presentation with the new tag
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}