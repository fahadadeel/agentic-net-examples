using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the slide collection
        Aspose.Slides.ISlideCollection slides = presentation.Slides;

        // Iterate through each slide by index
        for (int i = 0; i < slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = slides[i];
            Console.WriteLine("Processing slide index: " + i);
            // Additional slide processing can be performed here
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}