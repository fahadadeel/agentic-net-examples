using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a mathematical shape to the first slide
        Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build a math block representing the equation x + y = z
        Aspose.Slides.MathText.IMathBlock mathBlock = new Aspose.Slides.MathText.MathematicalText("x")
            .Join("+")
            .Join(new Aspose.Slides.MathText.MathematicalText("y"))
            .Join("=")
            .Join(new Aspose.Slides.MathText.MathematicalText("z"));

        // Add the math block to the paragraph
        mathParagraph.Add(mathBlock);

        // Save the presentation as XPS
        pres.Save("MathEquation.xps", Aspose.Slides.Export.SaveFormat.Xps);
    }
}