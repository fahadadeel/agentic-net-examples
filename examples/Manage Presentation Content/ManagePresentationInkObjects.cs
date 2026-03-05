using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        // Load an existing PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Iterate through all shapes on the slide to find Ink objects
        for (int i = 0; i < slide.Shapes.Count; i++)
        {
            Aspose.Slides.IShape shape = slide.Shapes[i];

            // Check if the shape is an Ink object
            if (shape is Aspose.Slides.Ink.Ink)
            {
                Aspose.Slides.Ink.Ink inkShape = (Aspose.Slides.Ink.Ink)shape;

                // Ensure the ink shape is visible
                inkShape.Hidden = false;

                // Retrieve the ink traces (read‑only property)
                Aspose.Slides.Ink.IInkTrace[] traces = inkShape.Traces;

                // Example processing: output the number of traces
                int traceCount = traces.Length;
                Console.WriteLine("Ink shape '{0}' contains {1} trace(s).", inkShape.Name, traceCount);
            }
        }

        // Save the modified presentation in PPTX format
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}