using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Define the source (font to replace) and destination (new font) font data
        Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("OldFontName");
        Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("NewFontName");

        // Replace all occurrences of the source font with the destination font
        presentation.FontsManager.ReplaceFont(sourceFont, destFont);

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}