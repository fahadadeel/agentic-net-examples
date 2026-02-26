using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Add a Fade animation effect that triggers on click
        Aspose.Slides.Animation.IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
            shape,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Configure the timing of the effect (rewind after playing)
        effect.Timing.Rewind = true;

        // Save the presentation
        string outputPath = System.IO.Path.Combine(
            System.IO.Directory.GetCurrentDirectory(),
            "AddShapeAnimationTiming.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}