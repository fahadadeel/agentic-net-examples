using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.docx";

        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        try
        {
            // Save the presentation as DOCX (using PPTX format with .docx extension)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        finally
        {
            // Ensure resources are released
            presentation.Dispose();
        }
    }
}