using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a mathematical shape to the first slide
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build the equation a + b = c using a MathBlock
        Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("a"));
        mathBlock.Join("+");
        mathBlock.Join(new Aspose.Slides.MathText.MathematicalText("b"));
        mathBlock.Join("=");
        mathBlock.Join(new Aspose.Slides.MathText.MathematicalText("c"));

        // Add the constructed block to the paragraph
        mathParagraph.Add(mathBlock);

        // Save the presentation as a multi-page TIFF image
        Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
        presentation.Save("MathEquation.tiff", Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
    }
}