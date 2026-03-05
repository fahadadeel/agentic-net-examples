using System;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Get the first shape as an AutoShape
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes[0];

        // Iterate through all paragraphs in the shape's text frame
        for (int i = 0; i < autoShape.TextFrame.Paragraphs.Count; i++)
        {
            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[i];

            // Add a Fly animation effect to the paragraph
            Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
                paragraph,
                Aspose.Slides.Animation.EffectType.Fly,
                Aspose.Slides.Animation.EffectSubtype.Left,
                Aspose.Slides.Animation.EffectTriggerType.OnClick);

            // Set the animate text type (e.g., by letter)
            effect.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}