using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Load the source presentation
        using (var pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Get the slide collection
            var slides = pres.Slides;

            // Clone the first slide and insert it at position 1
            slides.InsertClone(1, slides[0]);

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}