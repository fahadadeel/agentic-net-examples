using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide in the presentation
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Create a file stream to write the SVG output
        using (System.IO.Stream svgStream = System.IO.File.Create("slide_1.svg"))
        {
            // Convert the slide to SVG and write it to the stream
            slide.WriteAsSvg(svgStream);
        }

        // Save the (unchanged) presentation to a new file before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources held by the presentation
        presentation.Dispose();
    }
}