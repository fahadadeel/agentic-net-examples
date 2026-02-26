using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a Math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0f, 0f, 720f, 150f);

        // Retrieve the MathParagraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion).MathParagraph;

        // Build a simple equation: a + b = c
        mathParagraph.Add(
            new Aspose.Slides.MathText.MathematicalText("a")
                .Join("+")
                .Join(
                    new Aspose.Slides.MathText.MathematicalText("b")
                        .Join("=")
                        .Join(new Aspose.Slides.MathText.MathematicalText("c"))
                )
        );

        // (Optional) Get LaTeX representation of the equation
        string latex = mathParagraph.ToLatex();

        // Save the presentation as a TIFF image
        Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
        presentation.Save("MathEquation.tiff", Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
    }
}