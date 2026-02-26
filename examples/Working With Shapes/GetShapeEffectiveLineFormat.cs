using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("MyPresentation.pptx");

        // Access the first shape on the first slide
        Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];

        // Retrieve the line format (may be null for some shapes)
        Aspose.Slides.ILineFormat lineFormat = shape.LineFormat;

        if (lineFormat != null)
        {
            // Get effective line formatting data with inheritance applied
            Aspose.Slides.ILineFormatEffectiveData effectiveLineFormat = lineFormat.GetEffective();

            Console.WriteLine("Style: " + effectiveLineFormat.Style);
            Console.WriteLine("Width: " + effectiveLineFormat.Width);
            Console.WriteLine("Fill type: " + effectiveLineFormat.FillFormat.FillType);
        }
        else
        {
            Console.WriteLine("The shape does not have a line format.");
        }

        // Save the presentation before exiting
        pres.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}