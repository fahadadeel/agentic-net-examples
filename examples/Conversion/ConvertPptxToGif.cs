using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";

        // Path for the resulting GIF file
        string outputPath = "output.gif";

        // Load the presentation
        Presentation presentation = new Presentation(inputPath);

        // Save the presentation as an animated GIF
        presentation.Save(outputPath, SaveFormat.Gif);

        // Dispose the presentation (handled by the using statement if preferred)
        presentation.Dispose();

        Console.WriteLine("Presentation converted to GIF successfully.");
    }
}