using System;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Load the existing PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the slide transition of the first slide
        Aspose.Slides.ISlideShowTransition slideTransition = presentation.Slides[0].SlideShowTransition;

        // Set the transition duration to 2 seconds (2000 milliseconds)
        slideTransition.Duration = 2000;

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}