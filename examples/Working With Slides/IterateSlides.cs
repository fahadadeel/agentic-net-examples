using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string inputPath = "input.pptx";
        // Path to the output presentation
        string outputPath = "output.pptx";

        // Load the presentation from file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides in the presentation
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                // Example operation: write the slide number to the console
                Console.WriteLine("Slide Number: " + slide.SlideNumber);
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}