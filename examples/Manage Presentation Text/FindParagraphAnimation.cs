using System;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
            Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                    {
                        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];
                        Aspose.Slides.Animation.IEffect[] effects = mainSequence.GetEffectsByParagraph(paragraph);
                        Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}, Paragraph {paraIndex + 1}: {effects.Length} effect(s) found.");
                    }
                }
            }
        }

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}