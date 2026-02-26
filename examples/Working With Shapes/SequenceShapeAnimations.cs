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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);

        // Add text to the shape
        shape.AddTextFrame("Animated Text");

        // Get the main animation sequence
        Aspose.Slides.Animation.ISequence mainSeq = slide.Timeline.MainSequence;

        // Add first effect: Fade after previous
        Aspose.Slides.Animation.IEffect effect1 = mainSeq.AddEffect(shape, Aspose.Slides.Animation.EffectType.Fade, Aspose.Slides.Animation.EffectSubtype.None, Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Add second effect: Appear on click
        Aspose.Slides.Animation.IEffect effect2 = mainSeq.AddEffect(shape, Aspose.Slides.Animation.EffectType.Appear, Aspose.Slides.Animation.EffectSubtype.None, Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Set animate text type for the first effect
        effect1.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;

        // Save the presentation
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "SequenceShapeAnimations.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}