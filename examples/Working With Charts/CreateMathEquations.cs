using System;
using Aspose.Slides;
using Aspose.Slides.MathText;

namespace CreateMathEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a mathematical shape to the first slide
            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build a math block representing the equation a + b = c
            Aspose.Slides.MathText.IMathBlock equationBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("a"))
                .Join("+")
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join("=")
                .Join(new Aspose.Slides.MathText.MathematicalText("c"));

            // Add the equation block to the math paragraph
            mathParagraph.Add(equationBlock);

            // Export the equation to LaTeX format (optional usage)
            string latexString = mathParagraph.ToLatex();
            Console.WriteLine("LaTeX representation: " + latexString);

            // Save the presentation
            presentation.Save("MathEquations.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}