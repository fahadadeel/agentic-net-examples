using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output presentation files
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Retrieve embedded fonts
        Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

        // List embedded fonts
        Console.WriteLine("Embedded fonts in the presentation:");
        foreach (Aspose.Slides.IFontData font in embeddedFonts)
        {
            Console.WriteLine(font.FontName);
        }

        // Save the presentation (no modifications) before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}