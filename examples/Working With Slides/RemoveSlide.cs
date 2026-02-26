using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file
        string sourcePath = "input.pptx";
        // Path to the output presentation file
        string outputPath = "output.pptx";
        // Zero‑based index of the slide to remove
        int slideIndex = 2;

        // Load the presentation from disk
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Remove the slide at the specified index
            presentation.Slides.RemoveAt(slideIndex);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}