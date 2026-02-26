using System;
using System.Drawing;

namespace InkBrushColorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Cast the first shape to an Ink object
            Aspose.Slides.Ink.Ink ink = slide.Shapes[0] as Aspose.Slides.Ink.Ink;
            if (ink != null)
            {
                // Retrieve all ink traces
                Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;
                if (traces.Length > 0)
                {
                    // Get the brush of the first trace
                    Aspose.Slides.Ink.IInkBrush brush = traces[0].Brush;

                    // Set the brush color to Red
                    brush.Color = Color.Red;
                }
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}