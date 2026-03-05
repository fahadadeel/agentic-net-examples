using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Iterate through all slides and shapes to disable autofit
        for (System.Int32 slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
            for (System.Int32 shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                if (shape is Aspose.Slides.IAutoShape)
                {
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                    if (autoShape.TextFrame != null)
                    {
                        // Set autofit type to Normal (no autofit)
                        autoShape.TextFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Normal;
                    }
                }
            }
        }

        // Optionally update document properties
        Aspose.Slides.IDocumentProperties properties = presentation.DocumentProperties;
        properties.Author = "Author";
        properties.Title = "Title";

        // Save the updated presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}