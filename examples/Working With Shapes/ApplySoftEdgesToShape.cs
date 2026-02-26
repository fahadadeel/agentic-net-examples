using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Set a fill color for the shape
        shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;

        // Enable soft edge effect and set its radius
        shape.EffectFormat.EnableSoftEdgeEffect();
        shape.EffectFormat.SoftEdgeEffect.Radius = 10.0;

        // Save the presentation
        presentation.Save("SoftEdgeShape_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}