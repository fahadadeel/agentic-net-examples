using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideIterationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation from a file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Iterate through each slide in the presentation
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[index];
                // Example operation: output slide index
                Console.WriteLine("Processing slide number: " + (index + 1));
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}