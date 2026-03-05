using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Specify the slide index you want to retrieve
        int slideIndex = 0; // first slide (zero‑based)

        // Get the slide reference using the indexer
        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

        // Example usage: output the slide ID
        Console.WriteLine("Slide ID: " + slide.SlideId);

        // Save the presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}