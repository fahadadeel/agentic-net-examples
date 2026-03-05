using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation.
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide.
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with text.
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);
        autoShape.AddTextFrame("Hello Aspose.Slides Animation!");

        // Add a fade effect to the shape.
        Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
            autoShape,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Set the text animation type to ByLetter.
        effect.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;

        // Set a delay between animated text parts (10% of effect duration).
        effect.DelayBetweenTextParts = 10f;

        // Save the presentation.
        presentation.Save("AnimatedText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}