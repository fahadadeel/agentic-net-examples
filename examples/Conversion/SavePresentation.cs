using System;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        var inputPath = "input.pptx";

        // Path for the output PPT file
        var outputPath = "output.ppt";

        // Load the PPTX presentation
        using (var presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation in PPT format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}