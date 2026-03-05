using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set custom header text for all slides
        presentation.HeaderFooterManager.SetAllHeadersText("Custom Header");
        // Make header visible on all slides
        presentation.HeaderFooterManager.SetAllHeadersVisibility(true);

        // Set custom footer text for all slides
        presentation.HeaderFooterManager.SetAllFootersText("Custom Footer");
        // Make footer visible on all slides
        presentation.HeaderFooterManager.SetAllFootersVisibility(true);

        // Save the presentation to a file
        presentation.Save("CustomHeaderFooter.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}