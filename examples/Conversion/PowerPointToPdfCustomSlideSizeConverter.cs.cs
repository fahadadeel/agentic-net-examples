using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string inputPath;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "input.pptx"; // default input
        }

        // Build output PDF path
        string directory = System.IO.Path.GetDirectoryName(inputPath);
        string filenameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(inputPath);
        string outputPath = System.IO.Path.Combine(directory ?? "", filenameWithoutExt + ".pdf");

        // Load the presentation
        Presentation presentation = new Presentation(inputPath);

        // Set a custom slide size (e.g., 800x600 points) and ensure content fits
        presentation.SlideSize.SetSize(800f, 600f, SlideSizeScaleType.EnsureFit);

        // Save the presentation as PDF
        presentation.Save(outputPath, SaveFormat.Pdf);
    }
}