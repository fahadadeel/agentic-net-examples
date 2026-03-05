using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string inputPath = "source.pptx";
        // Path to the output presentation
        string outputPath = "output.pptx";

        // Load the existing presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Example operation: write the number of slides to console
            int slideCount = presentation.Slides.Count;
            Console.WriteLine("Number of slides: " + slideCount);

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}