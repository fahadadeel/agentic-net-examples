using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Add a Fly animation effect to the shape
        Aspose.Slides.Animation.IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
            shape,
            Aspose.Slides.Animation.EffectType.Fly,
            Aspose.Slides.Animation.EffectSubtype.Left,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Configure timing: set a trigger delay of 2 seconds
        effect.Timing.TriggerDelayTime = 2.0f;

        // Save the presentation before exiting
        string outputPath = System.IO.Path.Combine(
            System.IO.Directory.GetCurrentDirectory(),
            "AnimatedShape.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}