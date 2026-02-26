using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Set custom slide size with content scaling to ensure fit
        presentation.SlideSize.SetSize(540f, 720f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        // Set slide size to A4 paper with content maximized
        presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.A4Paper, Aspose.Slides.SlideSizeScaleType.Maximize);

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}