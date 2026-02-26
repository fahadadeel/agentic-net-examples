using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Make header and footer placeholders visible on all slides
        presentation.HeaderFooterManager.SetAllHeadersVisibility(true);
        presentation.HeaderFooterManager.SetAllFootersVisibility(true);

        // Set custom header and footer text for all slides
        presentation.HeaderFooterManager.SetAllHeadersText("Custom Header");
        presentation.HeaderFooterManager.SetAllFootersText("Custom Footer");

        // Save the presentation before exiting
        presentation.Save("CustomHeaderFooter.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}