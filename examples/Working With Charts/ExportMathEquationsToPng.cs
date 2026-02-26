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

        // Add a rectangle auto shape to host the mathematical equation
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0f, 0f, 720f, 150f);

        // Retrieve the math paragraph from the first portion of the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build the equation a² + b² = c² and add it to the paragraph
        mathParagraph.Add(
            new Aspose.Slides.MathText.MathematicalText("a").SetSuperscript("2")
                .Join(" + ")
                .Join(new Aspose.Slides.MathText.MathematicalText("b").SetSuperscript("2"))
                .Join(" = ")
                .Join(new Aspose.Slides.MathText.MathematicalText("c").SetSuperscript("2"))
        );

        // Export the shape (containing the equation) as a high‑resolution PNG image
        Aspose.Slides.IImage shapeImage = mathShape.GetImage();
        string imagePath = "math_equation.png";
        shapeImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        string presentationPath = "math_equation.pptx";
        presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}