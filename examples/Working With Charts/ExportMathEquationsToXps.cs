using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (var presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                var slide = presentation.Slides[0];

                // Add a Math shape to host the equation
                var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

                // Retrieve the MathParagraph from the shape
                var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Build a fraction x/y
                var fraction = new MathematicalText("x").Divide("y");
                mathParagraph.Add(new MathBlock(fraction));

                // Build the equation c² = a² + b²
                var mathBlock = new MathematicalText("c")
                    .SetSuperscript("2")
                    .Join("=")
                    .Join(new MathematicalText("a").SetSuperscript("2"))
                    .Join("+")
                    .Join(new MathematicalText("b").SetSuperscript("2"));
                mathParagraph.Add(mathBlock);

                // Optional: get LaTeX representation (not required for XPS export)
                // var latex = mathParagraph.ToLatex();

                // Configure XPS export options
                var xpsOptions = new Aspose.Slides.Export.XpsOptions();
                xpsOptions.SaveMetafilesAsPng = true; // example option

                // Save the presentation as XPS
                presentation.Save("MathEquations.xps", Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);
            }
        }
    }
}