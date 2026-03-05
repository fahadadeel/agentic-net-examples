using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Retrieve the fonts used in the presentation
        IFontData[] usedFonts = presentation.FontsManager.GetFonts();

        Console.WriteLine("Fonts used in the presentation:");
        foreach (IFontData font in usedFonts)
        {
            Console.WriteLine(font.FontName);
        }

        // Define source and destination fonts for replacement
        IFontData sourceFont = new FontData("Arial");
        IFontData destFont = new FontData("Times New Roman");

        // Replace the source font with the destination font
        presentation.FontsManager.ReplaceFont(sourceFont, destFont);

        // Save the presentation to a file
        presentation.Save("FontSelectionDemo.pptx", SaveFormat.Pptx);
    }
}