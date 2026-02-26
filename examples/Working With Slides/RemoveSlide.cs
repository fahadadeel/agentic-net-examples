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

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Ensure there is at least one slide to remove
            if (presentation.Slides.Count > 0)
            {
                // Remove the first slide (index 0)
                presentation.Slides.RemoveAt(0);
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}