using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access built‑in document properties
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
        Console.WriteLine("Title: " + docProps.Title);
        Console.WriteLine("Author: " + docProps.Author);
        Console.WriteLine("Created: " + docProps.CreatedTime);

        // Access slide collection and its properties
        Aspose.Slides.ISlideCollection slides = presentation.Slides;
        Console.WriteLine("Total slides: " + slides.Count);

        for (int i = 0; i < slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = slides[i];
            Console.WriteLine("Slide Number: " + slide.SlideNumber);
            Console.WriteLine("Slide Name: " + slide.Name);
            Console.WriteLine("Is Hidden: " + slide.Hidden);

            // Example: ensure the slide is not hidden
            slide.Hidden = false;

            // Example: read slide transition type
            Aspose.Slides.ISlideShowTransition transition = slide.SlideShowTransition;
            Console.WriteLine("Transition Type: " + transition.Type);
        }

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}