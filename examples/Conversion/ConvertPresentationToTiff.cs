using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string sourcePath = "input.pptx";
        // Path to the output TIFF file
        string outputPath = "output.tiff";

        // Load the presentation from the PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath);

        // Save the presentation as a multi‑page TIFF image
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff);

        // Release resources
        presentation.Dispose();
    }
}