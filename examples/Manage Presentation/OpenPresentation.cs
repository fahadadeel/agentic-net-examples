using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file
        string sourcePath = "sample.pptx";
        // Path for the output presentation file
        string outputPath = "output.pptx";

        // Open the presentation using the fully-qualified Aspose.Slides type
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Access the first slide (read-only property)
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

            // Save the presentation in PPTX format before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}