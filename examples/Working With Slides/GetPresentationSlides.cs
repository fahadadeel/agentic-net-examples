using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the slides collection
        Aspose.Slides.ISlideCollection slides = presentation.Slides;

        // Output the total number of slides
        Console.WriteLine("Total slides: " + slides.Count);

        // Iterate through each slide (example operation)
        for (int i = 0; i < slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = slides[i];
            Console.WriteLine("Processing slide index: " + i);
            // Additional slide processing can be added here
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}