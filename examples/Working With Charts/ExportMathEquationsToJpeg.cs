using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        // Paths for input and output files
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPptx = Path.Combine(dataDir, "output_math.pptx");
        string outputJpeg = Path.Combine(dataDir, "math_shape.jpg");

        // Load an existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a mathematical shape to the slide
        Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 400, 100);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build a simple equation: a + b = c
        mathParagraph.Add(
            new Aspose.Slides.MathText.MathematicalText("a")
                .Join("+")
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join("=")
                .Join(new Aspose.Slides.MathText.MathematicalText("c"))
        );

        // Export the shape as a JPEG image
        Aspose.Slides.IImage shapeImage = mathShape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1, 1);
        shapeImage.Save(outputJpeg, Aspose.Slides.ImageFormat.Jpeg);

        // Save the modified presentation
        pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}