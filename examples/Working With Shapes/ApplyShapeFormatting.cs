using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

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
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

        // Apply solid fill to the shape
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 100, 150, 200);

        // Apply line formatting to the shape
        shape.LineFormat.Width = 5;
        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 0, 0, 0);

        // Apply a preset shadow effect to the shape
        shape.EffectFormat.EnablePresetShadowEffect();
        shape.EffectFormat.PresetShadowEffect.Preset = Aspose.Slides.PresetShadowType.TopLeftDropShadow;
        shape.EffectFormat.PresetShadowEffect.Distance = 5.0;
        shape.EffectFormat.PresetShadowEffect.Direction = 45.0f;

        // Save the presentation
        presentation.Save("FormattedShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}