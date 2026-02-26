using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the presentation-wide header/footer manager
        Aspose.Slides.IPresentationHeaderFooterManager headerFooterManager = presentation.HeaderFooterManager;

        // Set header text (appears on notes and handout slides)
        headerFooterManager.SetAllHeadersText("Header text");

        // Set footer text (appears on all slides)
        headerFooterManager.SetAllFootersText("Footer text");

        // Ensure header and footer placeholders are visible
        headerFooterManager.SetAllHeadersVisibility(true);
        headerFooterManager.SetAllFootersVisibility(true);

        // Save the presentation to a file
        presentation.Save("HeaderFooterPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}