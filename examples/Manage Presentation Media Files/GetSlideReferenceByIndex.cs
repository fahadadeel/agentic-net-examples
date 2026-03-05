using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a new empty slide using the layout of the first slide
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Retrieve a slide reference by its index (e.g., the first slide)
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

        // Display a message confirming retrieval
        Console.WriteLine("Slide at index 0 retrieved successfully.");

        // Save the presentation in PPTX format
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}