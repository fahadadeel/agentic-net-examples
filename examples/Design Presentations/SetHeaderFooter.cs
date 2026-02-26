using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set custom text for all header placeholders (notes, handout, etc.)
        presentation.HeaderFooterManager.SetAllHeadersText("Custom Header");

        // Set custom text for all footer placeholders (slides, master slides, etc.)
        presentation.HeaderFooterManager.SetAllFootersText("Custom Footer");

        // Ensure footer placeholder is visible on each slide
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            if (!slide.HeaderFooterManager.IsFooterVisible)
            {
                slide.HeaderFooterManager.SetFooterVisibility(true);
            }
        }

        // Save the presentation before exiting
        presentation.Save("CustomizedHeaderFooter.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}