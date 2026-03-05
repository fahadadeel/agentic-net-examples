using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
            // Get the main animation sequence of the slide
            Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                // Process only AutoShapes that contain a TextFrame
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    // Iterate through all paragraphs in the TextFrame
                    for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                    {
                        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];
                        // Retrieve animation effects for the current paragraph
                        Aspose.Slides.Animation.IEffect[] effects = mainSequence.GetEffectsByParagraph(paragraph);
                        // Output the number of effects found
                        Console.WriteLine("Slide {0}, Shape {1}, Paragraph {2} has {3} effect(s).",
                            slideIndex, shapeIndex, paraIndex, effects.Length);
                    }
                }
            }
        }

        // Save the presentation (required before exit)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}