using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the slide collection
        Aspose.Slides.ISlideCollection slides = presentation.Slides;

        // Iterate through each slide
        for (int i = 0; i < slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = slides[i];
            Console.WriteLine("Processing slide index: " + i);
            // Additional slide processing can be added here
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}