using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace CreateMathEquations
{
    public class Program
    {
        public static void Main()
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a mathematical shape to the first slide
            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the equation a + b = c
            mathParagraph.Add(
                new Aspose.Slides.MathText.MathematicalText("a")
                    .Join("+")
                    .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                    .Join("=")
                    .Join(new Aspose.Slides.MathText.MathematicalText("c"))
            );

            // Export the equation to LaTeX format
            string latexString = mathParagraph.ToLatex();
            Console.WriteLine("LaTeX representation: " + latexString);

            // Save the presentation
            presentation.Save("MathEquations.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}