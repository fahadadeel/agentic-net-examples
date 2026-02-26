using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve the slide reference by its zero‑based index
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Example operation: display the slide's unique identifier
        Console.WriteLine("Slide ID: " + slide.SlideId);

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}