using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access slideshow transition information for each slide
        int slideCount = presentation.Slides.Count;
        for (int i = 0; i < slideCount; i++)
        {
            Aspose.Slides.ISlideShowTransition transition = presentation.Slides[i].SlideShowTransition;
            Console.WriteLine("Slide " + (i + 1) + " Transition Type: " + transition.Type);
            Console.WriteLine("Slide " + (i + 1) + " Transition Duration (ms): " + transition.Duration);
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}