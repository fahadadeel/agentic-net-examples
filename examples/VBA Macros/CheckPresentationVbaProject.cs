using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputFileName = "input.pptx";
        string inputFilePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), inputFileName);

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFilePath);

        // Determine whether the presentation contains a VBA project
        bool containsVbaProject = presentation.VbaProject != null;

        Console.WriteLine("Presentation contains VBA project: " + containsVbaProject);

        // Save the presentation before exiting (no modifications made)
        string outputFileName = "output.pptx";
        string outputFilePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), outputFileName);
        presentation.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}