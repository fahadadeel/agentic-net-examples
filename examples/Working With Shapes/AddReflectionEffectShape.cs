using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Enable reflection effect on the shape
        Aspose.Slides.IEffectFormat effectFormat = shape.EffectFormat;
        effectFormat.EnableReflectionEffect();

        // Customize reflection properties
        Aspose.Slides.Effects.IReflection reflection = effectFormat.ReflectionEffect;
        reflection.BlurRadius = 5.0;
        reflection.Distance = 5.0;
        reflection.StartReflectionOpacity = 80.0f;
        reflection.EndReflectionOpacity = 0.0f;

        // Save the presentation
        presentation.Save("ReflectionEffect.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}