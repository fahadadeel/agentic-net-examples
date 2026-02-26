using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        var presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        var slide = presentation.Slides[0];

        // Assume the first shape on the slide is an Ink shape
        var shape = slide.Shapes[0];
        var ink = shape as Aspose.Slides.Ink.IInk;

        if (ink != null)
        {
            // Retrieve all ink traces
            Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;

            // Iterate through each trace and output point count
            for (int i = 0; i < traces.Length; i++)
            {
                Aspose.Slides.Ink.IInkTrace trace = traces[i];
                PointF[] points = trace.Points;
                Console.WriteLine($"Trace {i} contains {points.Length} points.");
            }
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}