using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all slides in the presentation
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Get the main animation sequence for the current slide
            Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // Process only AutoShape objects that contain a text frame
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    // Iterate through each paragraph in the text frame
                    for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                    {
                        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];

                        // Retrieve animation effects applied to this paragraph
                        Aspose.Slides.Animation.IEffect[] effects = mainSequence.GetEffectsByParagraph(paragraph);

                        Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}, Paragraph {paraIndex + 1}: {effects.Length} effect(s)");

                        // Output details of each effect
                        for (int e = 0; e < effects.Length; e++)
                        {
                            Aspose.Slides.Animation.IEffect effect = effects[e];
                            Console.WriteLine($"  Effect {e + 1}: Type={effect.Type}, Subtype={effect.Subtype}");
                        }
                    }
                }
            }
        }

        // Save the presentation (required by the authoring rules)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}