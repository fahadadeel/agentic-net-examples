using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a math shape to the slide
            Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(50f, 50f, 400f, 100f);

            // Retrieve the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion).MathParagraph;

            // Build a mathematical block for the expression "(a + b) * c"
            Aspose.Slides.MathText.IMathBlock innerBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("a"))
                .Join(" + ")
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join(") * ")
                .Join(new Aspose.Slides.MathText.MathematicalText("c"));

            // Prepend opening parenthesis using JoinBlock
            Aspose.Slides.MathText.IMathBlock fullBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("(")).JoinBlock(innerBlock);

            // Add the block to the paragraph
            mathParagraph.Add(fullBlock);

            // Demonstrate arithmetic on shape property: increase width by 20%
            float originalWidth = mathShape.Width;
            mathShape.Width = originalWidth * 1.2f;

            // Save the presentation
            presentation.Save("ArithmeticMathShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}