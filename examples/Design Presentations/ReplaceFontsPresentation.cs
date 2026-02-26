using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Create font data objects for source and replacement fonts
            Aspose.Slides.FontData sourceFont = new Aspose.Slides.FontData("Arial");
            Aspose.Slides.FontData destFont = new Aspose.Slides.FontData("Times New Roman");

            // Replace the source font with the destination font in the entire presentation
            presentation.FontsManager.ReplaceFont(sourceFont, destFont);

            // Save the updated presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}