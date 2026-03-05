using System;

namespace MyPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Enable slide number placeholders for all slides in the presentation
            presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

            // Save the presentation to a file
            presentation.Save("SlideNumbers.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}