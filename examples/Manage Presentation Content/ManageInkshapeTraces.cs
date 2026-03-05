using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        // Load an existing PPT presentation
        Presentation presentation = new Presentation("input.pptx");

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Cast the first shape on the slide to an Ink object
        IInk ink = (IInk)slide.Shapes[0];

        // Retrieve all ink traces from the Ink shape
        IInkTrace[] traces = ink.Traces;

        // Iterate through each trace and output the number of points it contains
        for (int i = 0; i < traces.Length; i++)
        {
            IInkTrace trace = traces[i];
            PointF[] points = trace.Points;
            Console.WriteLine($"Trace {i} contains {points.Length} points.");
        }

        // Save the presentation after processing
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}