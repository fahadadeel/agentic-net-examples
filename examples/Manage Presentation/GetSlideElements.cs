using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";
        // Path where the modified PPTX will be saved
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide in the presentation
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Iterate through all shapes on the slide
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            // Retrieve fill and line formats (read‑only properties)
            Aspose.Slides.IFillFormat fillFormat = shape.FillFormat;
            Aspose.Slides.ILineFormat lineFormat = shape.LineFormat;

            // Example output: shape name, fill type, line width
            Console.WriteLine($"Shape: {shape.Name}, Fill type: {fillFormat.FillType}, Line width: {lineFormat.Width}");
        }

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}