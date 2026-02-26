using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Create a file stream to write the SVG output
        using (FileStream svgStream = File.Create("slide_1.svg"))
        {
            // Render the slide as SVG
            slide.WriteAsSvg(svgStream);
        }

        // Save the presentation (required before exiting)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}