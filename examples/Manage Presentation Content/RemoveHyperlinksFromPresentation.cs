using System;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Load the presentation from a PPTX file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Remove all hyperlinks from the presentation
            presentation.HyperlinkQueries.RemoveAllHyperlinks();

            // Save the presentation after removing hyperlinks
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}