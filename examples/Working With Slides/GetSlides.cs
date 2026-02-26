using System;

namespace AccessSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation from a file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Get the collection of slides
            Aspose.Slides.ISlideCollection slides = presentation.Slides;

            // Iterate through each slide and access it
            for (int index = 0; index < slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = slides[index];
                Console.WriteLine("Accessed slide number: " + (index + 1));
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}