using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle auto shape to host a mathematical equation
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Create a math block using the constructor that takes an IMathElement to avoid ambiguity
        Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("x"));
        // Add the math block to the paragraph
        mathParagraph.Add(mathBlock);

        // Add a chart (required by the get-chart-image rule) – the chart itself will be used to obtain an image
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0, 100, 500, 300);

        // Get the chart image (this demonstrates the get-chart-image rule)
        Aspose.Slides.IImage chartImage = chart.GetImage();

        // Save the image as PNG – this represents the exported math equation image
        chartImage.Save("mathEquation.png", Aspose.Slides.ImageFormat.Png);

        // Save the presentation before exiting
        presentation.Save("ExportMathEquationsToPng.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}