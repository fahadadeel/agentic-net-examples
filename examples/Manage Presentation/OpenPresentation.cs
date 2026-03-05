using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file (any supported format)
        string sourcePath = "sample.pptx";

        // Path where the presentation will be saved
        string destinationPath = "converted.pptx";

        // Open the presentation using the fully-qualified type
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Save the presentation in PPTX format before exiting
            presentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}