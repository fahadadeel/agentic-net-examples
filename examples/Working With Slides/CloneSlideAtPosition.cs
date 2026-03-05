using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "source.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the slide collection
        Aspose.Slides.ISlideCollection slides = pres.Slides;

        // Clone the first slide and insert it at position 2 (zero‑based index)
        slides.InsertClone(2, slides[0]);

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}