using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Path to the source PPT file
        System.String inputPath = "input.ppt";
        // Path to the destination PPTX file
        System.String outputPath = "output.pptx";

        // Load the PPT presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        // Save the presentation in PPTX format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        // Release resources
        presentation.Dispose();
    }
}