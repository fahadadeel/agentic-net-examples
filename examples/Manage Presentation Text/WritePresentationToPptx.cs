using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string sourcePath = "input.pptx";
        // Path to the output PPTX file
        string outputPath = "output.pptx";

        // Load the presentation from the source file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath);

        // Save the presentation in PPTX format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}