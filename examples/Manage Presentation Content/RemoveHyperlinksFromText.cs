using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveHyperlinksExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the PPTX presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Remove all hyperlinks (click and mouse over) from the presentation
            presentation.HyperlinkQueries.RemoveAllHyperlinks();

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}