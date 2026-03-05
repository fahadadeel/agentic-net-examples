using System;
using Aspose.Slides;

namespace SetTextCharacterSpacing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape to the slide
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100f,   // X position
                100f,   // Y position
                400f,   // Width
                100f    // Height
            );

            // Add a TextFrame with initial text
            shape.AddTextFrame("Sample text for character spacing");

            // Access the first paragraph and its first portion
            Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];
            Aspose.Slides.IPortion portion = paragraph.Portions[0];

            // Set character spacing (intercharacter spacing) in points
            portion.PortionFormat.Spacing = 5f;

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}