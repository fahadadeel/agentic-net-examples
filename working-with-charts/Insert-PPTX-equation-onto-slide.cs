using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace InsertEquationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a rectangle shape to host the mathematical equation
                IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0f, 0f, 720f, 150f);

                // Retrieve the MathParagraph from the shape
                IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

                // Build the equation: c² = a² + b²
                IMathBlock equationBlock = new MathematicalText("c")
                    .SetSuperscript("2")
                    .Join("=")
                    .Join(new MathematicalText("a").SetSuperscript("2"))
                    .Join("+")
                    .Join(new MathematicalText("b").SetSuperscript("2"));

                // Add the equation to the paragraph
                mathParagraph.Add(equationBlock);

                // Save the presentation
                string outPath = Path.Combine(Directory.GetCurrentDirectory(), "Equation.pptx");
                presentation.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}