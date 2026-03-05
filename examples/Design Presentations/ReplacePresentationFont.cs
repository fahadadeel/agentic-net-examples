using System;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Define source and destination fonts
        Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
        Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Times New Roman");

        // Replace the source font with the destination font
        presentation.FontsManager.ReplaceFont(sourceFont, destFont);

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}