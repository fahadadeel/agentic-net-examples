using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using Aspose.Slides.MathText;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Aspose.Slides.Presentation();

                // Add a chart to the first slide
                var slide = presentation.Slides[0];
                var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 100, 100, 400, 300);
                var workbook = chart.ChartData.ChartDataWorkbook;

                // Populate cells with values
                workbook.GetCell(0, "B2", 2);
                workbook.GetCell(0, "B3", 3);
                // Set a formula that sums B2 and B3
                workbook.GetCell(0, "B4").Formula = "B2+B3";

                // Calculate all formulas in the workbook
                workbook.CalculateFormulas();

                // Add a math shape to demonstrate built‑in calculation features
                var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);
                var mathPortion = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion);
                var mathParagraph = mathPortion.MathParagraph;

                // Create a simple fraction math block (x / y)
                var fraction = new MathematicalText("x").Divide("y");
                mathParagraph.Add(new MathBlock(fraction));

                // Create a quadratic formula block: c² = a² + b²
                var quadraticBlock = new MathematicalText("c")
                    .SetSuperscript("2")
                    .Join("=")
                    .Join(new MathematicalText("a").SetSuperscript("2"))
                    .Join("+")
                    .Join(new MathematicalText("b").SetSuperscript("2"));
                mathParagraph.Add(quadraticBlock);

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}