using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a mathematical shape to the first slide
        IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Get the math paragraph from the shape
        IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build a math block representing the equation a + b = c
        MathBlock mathBlock = new MathBlock(new MathematicalText("a"));
        mathBlock.Join("+");
        mathBlock.Join(new MathematicalText("b"));
        mathBlock.Join("=");
        mathBlock.Join(new MathematicalText("c"));

        // Add the math block to the paragraph
        mathParagraph.Add(mathBlock);

        // Save the presentation as PDF
        pres.Save("MathEquation.pdf", SaveFormat.Pdf);

        // Dispose the presentation
        pres.Dispose();
    }
}