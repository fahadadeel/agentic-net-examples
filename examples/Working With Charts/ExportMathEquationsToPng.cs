using System;
using Aspose.Slides;
using Aspose.Slides.MathText;

namespace ExportMathEquationsToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a math shape to the first slide
            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0f, 0f, 500f, 50f);

            // Get the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build a simple equation: a + b = c
            Aspose.Slides.MathText.IMathBlock equationBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("a"))
                .Join("+")
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join("=")
                .Join(new Aspose.Slides.MathText.MathematicalText("c"));

            // Add the equation to the math paragraph
            mathParagraph.Add(equationBlock);

            // Render the slide to a high‑resolution PNG image
            float scaleX = 3f; // 300% scaling on X axis
            float scaleY = 3f; // 300% scaling on Y axis
            Aspose.Slides.IImage slideImage = presentation.Slides[0].GetImage(scaleX, scaleY);
            slideImage.Save("MathEquation.png", Aspose.Slides.ImageFormat.Png);

            // Save the presentation (required by the rules)
            presentation.Save("MathEquationPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}