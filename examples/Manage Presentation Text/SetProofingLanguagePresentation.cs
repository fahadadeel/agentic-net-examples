using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string sourcePath = "input.pptx";
        // Path to the output presentation
        string outputPath = "output.pptx";

        // Load the presentation from file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath);

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // Process only AutoShape objects that contain a TextFrame
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                    // Iterate through all paragraphs in the TextFrame
                    for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                    {
                        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[paraIndex];

                        // Iterate through all portions in the paragraph
                        for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                        {
                            Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];

                            // Set the proofing language (e.g., French - France)
                            portion.PortionFormat.LanguageId = "fr-FR";
                        }
                    }
                }
            }
        }

        // Save the modified presentation as PPTX
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}