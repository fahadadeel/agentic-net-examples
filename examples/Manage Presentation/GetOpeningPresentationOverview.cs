using System;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file
        string sourcePath = "Sample.pptx";
        // Path where the opened presentation will be saved
        string outputPath = "OpenedPresentation_out.pptx";

        // Open the existing presentation using the fully-qualified Presentation type
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Retrieve the total number of slides
            int slideCount = presentation.Slides.Count;
            Console.WriteLine("Total slides: " + slideCount);

            // Iterate through slides and display their IDs
            for (int i = 0; i < slideCount; i++)
            {
                uint slideId = presentation.Slides[i].SlideId;
                Console.WriteLine("Slide " + (i + 1) + " ID: " + slideId);
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}