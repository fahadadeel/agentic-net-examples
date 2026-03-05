using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("MyPresentation.pptx");

        // Get the first shape on the first slide
        Aspose.Slides.IShape shape = presentation.Slides[0].Shapes[0];

        // Retrieve the line format (may be null for some shapes)
        Aspose.Slides.ILineFormat lineFormat = shape.LineFormat;

        if (lineFormat != null)
        {
            // Get effective line formatting data with inheritance applied
            Aspose.Slides.ILineFormatEffectiveData effectiveLineFormat = lineFormat.GetEffective();

            // Output effective line format properties
            Console.WriteLine("Style: " + effectiveLineFormat.Style);
            Console.WriteLine("Width: " + effectiveLineFormat.Width);
            Console.WriteLine("Fill type: " + effectiveLineFormat.FillFormat.FillType);
        }
        else
        {
            Console.WriteLine("Shape does not have a line format.");
        }

        // Save the presentation before exiting
        presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}