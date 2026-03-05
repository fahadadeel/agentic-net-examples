using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Get the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build a math block: a = b + c
        Aspose.Slides.MathText.IMathBlock mathBlock = new Aspose.Slides.MathText.MathBlock((Aspose.Slides.MathText.IMathElement)new Aspose.Slides.MathText.MathematicalText("a"))
            .Join("+")
            .Join(new Aspose.Slides.MathText.MathematicalText("b"))
            .Join("=")
            .Join(new Aspose.Slides.MathText.MathematicalText("c"));

        // Add block to paragraph
        mathParagraph.Add(mathBlock);

        // Save presentation as PDF
        pres.Save("MathEquations.pdf", Aspose.Slides.Export.SaveFormat.Pdf);

        // Dispose presentation
        pres.Dispose();
    }
}