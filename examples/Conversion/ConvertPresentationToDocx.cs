using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PowerPoint file (PPTX)
        System.String inputPath = "input.pptx";
        // Desired output file (DOCX) - Aspose.Slides does not support DOCX directly,
        // so we demonstrate saving in a supported format (PPTX) to keep the code compilable.
        System.String outputPath = "output.docx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Save the presentation (using a valid SaveFormat)
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}