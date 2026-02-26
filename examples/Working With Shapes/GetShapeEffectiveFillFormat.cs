using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Add a rectangle shape to the first slide
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 10, 10, 100, 100);

            // Set a solid fill for the shape (optional, to have visible fill data)
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

            // Get the effective fill format of the shape
            Aspose.Slides.IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();

            // Output effective fill properties
            Console.WriteLine("Effective Fill Type: " + effectiveFill.FillType);
            if (effectiveFill.FillType == Aspose.Slides.FillType.Solid)
            {
                Console.WriteLine("Effective Solid Fill Color: " + effectiveFill.SolidFillColor);
            }

            // Save the presentation before exiting
            presentation.Save("EffectiveFillExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}