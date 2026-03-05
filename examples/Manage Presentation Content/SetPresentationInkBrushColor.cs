using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Cast the first shape on the first slide to an Ink object
        Aspose.Slides.Ink.IInk ink = (Aspose.Slides.Ink.IInk)pres.Slides[0].Shapes[0];

        // Retrieve the ink traces
        Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;

        // Change the brush color of the first trace
        Aspose.Slides.Ink.IInkBrush brush = traces[0].Brush;
        brush.Color = Color.Red;

        // Save the modified presentation in PPT format
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}