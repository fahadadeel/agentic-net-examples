using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace ExportMathToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Add a mathematical shape to the first slide
                Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

                // Retrieve the math paragraph from the shape
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Build a math block representing the equation a + b = c
                Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock();
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("a"));
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("+"));
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("b"));
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("="));
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("c"));

                // Add the math block to the paragraph
                mathParagraph.Add(mathBlock);

                // Set XPS export options (optional customizations can be added here)
                Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();

                // Save the presentation as XPS
                presentation.Save("MathEquation.xps", Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);
            }
        }
    }
}