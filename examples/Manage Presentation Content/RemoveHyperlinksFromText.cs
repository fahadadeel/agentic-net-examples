using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Remove all hyperlinks (click and mouse over) from the presentation
        presentation.HyperlinkQueries.RemoveAllHyperlinks();

        // Save the presentation after removing hyperlinks
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}