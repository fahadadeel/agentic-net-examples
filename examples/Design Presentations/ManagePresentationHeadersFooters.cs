using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the presentation-wide header/footer manager
        Aspose.Slides.IPresentationHeaderFooterManager headerFooterManager = presentation.HeaderFooterManager;

        // Make footers, date-time and slide numbers visible on all slides
        headerFooterManager.SetAllFootersVisibility(true);
        headerFooterManager.SetAllDateTimesVisibility(true);
        headerFooterManager.SetAllSlideNumbersVisibility(true);

        // Set common text for footers and date-time placeholders
        headerFooterManager.SetAllFootersText("Sample Footer");
        headerFooterManager.SetAllDateTimesText("01/01/2026");

        // Save the presentation before exiting
        presentation.Save("ManagedHeadersFooters.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}