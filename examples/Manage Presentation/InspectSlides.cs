using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load an existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the collection of slides
        Aspose.Slides.ISlideCollection slides = presentation.Slides;

        // Iterate through each slide and inspect
        for (int i = 0; i < slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = slides[i];
            // Example inspection: output slide index
            Console.WriteLine("Slide index: " + i);
            // Additional inspection logic can be placed here
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}