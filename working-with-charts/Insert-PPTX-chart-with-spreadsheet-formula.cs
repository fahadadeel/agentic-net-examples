using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartWithFormulaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a pie chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 100f, 100f, 300f, 400f);

                // Get the chart's data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Populate cells with values
                workbook.GetCell(0, "B2", 2);
                workbook.GetCell(0, "B3", 3);

                // Assign a formula to a cell (B4 = B2 + B3)
                workbook.GetCell(0, "B4").Formula = "B2+B3";

                // Calculate all formulas in the workbook
                workbook.CalculateFormulas();

                // Save the presentation
                pres.Save("ChartWithFormula.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}