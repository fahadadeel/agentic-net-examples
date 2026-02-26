using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Enable and configure the glow effect
        shape.EffectFormat.EnableGlowEffect();
        shape.EffectFormat.GlowEffect.Radius = 10.0;
        // Set the glow color (blue)
        shape.EffectFormat.GlowEffect.Color.Color = Color.FromArgb(255, 0, 0, 255);

        // Enable and configure the outer shadow effect
        shape.EffectFormat.EnableOuterShadowEffect();
        shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
        shape.EffectFormat.OuterShadowEffect.Direction = 45.0f;
        shape.EffectFormat.OuterShadowEffect.Distance = 3.0;
        // Set the shadow color (semi‑transparent black)
        shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0);

        // Save the presentation before exiting
        presentation.Save("CombineShapeEffects.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}