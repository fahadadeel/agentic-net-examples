using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Define file paths
        string inputPath = "input.pptx";
        string outputSvgPath = "slide_1.svg";
        string savedPresentationPath = "output.pptx";

        // Load the presentation from the specified file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide (index 0)
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Export the slide to an SVG file
        using (FileStream svgStream = File.Create(outputSvgPath))
        {
            slide.WriteAsSvg(svgStream);
        }

        // Save the presentation before exiting (required by authoring rules)
        pres.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}