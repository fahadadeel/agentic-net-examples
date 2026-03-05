using System;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Load the existing presentation
        using (var presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Find and replace text throughout the presentation (including master slides)
            Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true, "[placeholder]", "New Text", null);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}