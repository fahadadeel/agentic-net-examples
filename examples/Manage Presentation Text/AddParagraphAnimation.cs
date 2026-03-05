using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an AutoShape with two paragraphs of text
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 100);
        autoShape.AddTextFrame("First paragraph.\nSecond paragraph.");

        // Get the first paragraph
        Aspose.Slides.IParagraph paragraph1 = autoShape.TextFrame.Paragraphs[0];
        // Add Fly animation effect to the first paragraph
        Aspose.Slides.Animation.IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
            paragraph1,
            Aspose.Slides.Animation.EffectType.Fly,
            Aspose.Slides.Animation.EffectSubtype.Left,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);
        // Set animate text type to ByLetter
        effect1.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;

        // Get the second paragraph
        Aspose.Slides.IParagraph paragraph2 = autoShape.TextFrame.Paragraphs[1];
        // Add Fade animation effect to the second paragraph
        Aspose.Slides.Animation.IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
            paragraph2,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
        // Set animate text type to ByWord
        effect2.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByWord;

        // Save the presentation
        presentation.Save("ParagraphAnimations_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}