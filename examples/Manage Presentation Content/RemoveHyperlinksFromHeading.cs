using System;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Remove all hyperlinks from the presentation (including headings)
        presentation.HyperlinkQueries.RemoveAllHyperlinks();

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}