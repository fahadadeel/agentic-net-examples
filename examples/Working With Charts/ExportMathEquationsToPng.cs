using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace ExportMathEquationsToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file paths
            System.String outputPptx = "MathEquation.pptx";
            System.String outputPng = "MathEquation.png";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a math shape to the first slide
            Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Get the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the equation a + b = c and add it to the paragraph
            mathParagraph.Add(
                new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("a"))
                    .Join("+")
                    .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                    .Join("=")
                    .Join(new Aspose.Slides.MathText.MathematicalText("c"))
            );

            // Define scaling for the shape thumbnail
            int scaleX = 2;
            int scaleY = 2;

            // Export the math shape as a PNG image
            Aspose.Slides.IImage shapeImage = mathShape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

            // Save the presentation
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}