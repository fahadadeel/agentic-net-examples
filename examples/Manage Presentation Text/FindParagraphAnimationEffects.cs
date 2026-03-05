using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Assume the first shape is an AutoShape with a text frame
        Aspose.Slides.IAutoShape autoShape = slide.Shapes[0] as Aspose.Slides.IAutoShape;
        if (autoShape != null && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
        {
            // Get the first paragraph
            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

            // Access the main animation sequence of the slide
            Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

            // Retrieve all effects applied to the paragraph
            Aspose.Slides.Animation.IEffect[] effects = mainSequence.GetEffectsByParagraph(paragraph);

            // Output effect details
            for (int i = 0; i < effects.Length; i++)
            {
                Aspose.Slides.Animation.IEffect effect = effects[i];
                Console.WriteLine("Effect {0}: Type = {1}, Subtype = {2}",
                    i,
                    effect.Type,
                    effect.Subtype);
            }
        }

        // Save the presentation (required by authoring rules)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}