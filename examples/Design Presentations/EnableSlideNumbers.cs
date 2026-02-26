using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the presentation header/footer manager
        Aspose.Slides.IPresentationHeaderFooterManager headerFooterManager = presentation.HeaderFooterManager;

        // Enable slide numbers for all slides
        headerFooterManager.SetAllSlideNumbersVisibility(true);

        // Save the presentation
        presentation.Save("SlideNumbersPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}