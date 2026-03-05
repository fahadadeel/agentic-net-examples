using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
        // Fill
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;
        // Border
        shape.LineFormat.Width = 5;
        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkBlue;
        // Effects
        shape.EffectFormat.EnableOuterShadowEffect();
        shape.EffectFormat.OuterShadowEffect.Distance = 5;
        shape.EffectFormat.OuterShadowEffect.BlurRadius = 4;
        shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = System.Drawing.Color.Gray;
        shape.EffectFormat.EnableGlowEffect();
        shape.EffectFormat.GlowEffect.Radius = 10;
        shape.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Yellow;
        // Save
        presentation.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}