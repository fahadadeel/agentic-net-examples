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
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Create a fraction x / y and add it as a math block
        Aspose.Slides.MathText.IMathElement fraction = new Aspose.Slides.MathText.MathematicalText("x").Divide("y");
        mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(fraction));

        // Build the equation c² = a² + b²
        Aspose.Slides.MathText.MathBlock equationBlock = new Aspose.Slides.MathText.MathBlock(
            (Aspose.Slides.MathText.IMathElement)new Aspose.Slides.MathText.MathematicalText("c").SetSuperscript("2"));
        equationBlock
            .Join("=")
            .Join(new Aspose.Slides.MathText.MathematicalText("a").SetSuperscript("2"))
            .Join("+")
            .Join(new Aspose.Slides.MathText.MathematicalText("b").SetSuperscript("2"));

        // Add the equation block to the paragraph
        mathParagraph.Add(equationBlock);

        // Save the presentation
        presentation.Save("AddMathEquation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}