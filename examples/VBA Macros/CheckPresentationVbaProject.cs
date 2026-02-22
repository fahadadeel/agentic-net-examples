using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file name
        string inputFileName = "input.pptx";
        // Build full path to the file
        string presentationPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath);
        // Determine whether a VBA project is attached
        bool containsVbaProject = presentation.VbaProject != null;
        Console.WriteLine("Presentation contains VBA project: " + containsVbaProject);
        // Save the presentation before exiting (no modifications made)
        presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}