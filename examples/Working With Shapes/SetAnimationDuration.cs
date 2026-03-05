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

        // Add an entrance effect to the shape
        Aspose.Slides.Animation.IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
            shape,
            Aspose.Slides.Animation.EffectType.Fly,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Set the duration of the animation effect to 2 seconds
        effect.Timing.Duration = 2.0f;

        // Save the presentation before exiting
        presentation.Save("AnimationDuration.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}