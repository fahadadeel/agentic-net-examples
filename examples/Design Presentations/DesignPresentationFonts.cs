using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Define the source font (to be replaced) and the destination font (replacement)
        Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
        Aspose.Slides.IFontData destinationFont = new Aspose.Slides.FontData("Calibri");

        // Replace the source font with the destination font throughout the presentation
        presentation.FontsManager.ReplaceFont(sourceFont, destinationFont);

        // Save the modified presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}