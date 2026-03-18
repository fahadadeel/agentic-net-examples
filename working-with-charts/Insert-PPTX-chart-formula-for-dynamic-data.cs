using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFormulaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.ClusteredColumn,
                        0, 0, 500, 400);

                    // Get the chart's data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Populate cells with static values
                    workbook.GetCell(0, "B2", 2);
                    workbook.GetCell(0, "B3", 3);

                    // Set a formula in cell B4 to sum B2 and B3
                    workbook.GetCell(0, "B4").Formula = "B2+B3";

                    // Calculate all formulas in the workbook
                    workbook.CalculateFormulas();

                    // Save the presentation
                    pres.Save("ChartWithFormula.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}