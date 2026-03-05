using System;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation
            var presentation = new Aspose.Slides.Presentation("input.pptx");

            // Retrieve the slide at index 0
            var slide = presentation.Slides[0];

            // Example operation: write the slide index to console
            Console.WriteLine("Retrieved slide index: 0");

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}