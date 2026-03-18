using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RetrieveEmbeddedFormulaResults
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Define output path
                string outPath = Path.Combine(Directory.GetCurrentDirectory(), "Result.pptx");

                // Add a clustered column chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Access the chart's data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Get cells and assign formulas
                Aspose.Slides.Charts.IChartDataCell cellA1 = workbook.GetCell(0, "A1");
                cellA1.Formula = "2+3";

                Aspose.Slides.Charts.IChartDataCell cellR1C1 = workbook.GetCell(0, "R1C1");
                cellR1C1.R1C1Formula = "5*2";

                // Calculate all formulas in the workbook
                workbook.CalculateFormulas();

                // Retrieve calculated values
                object resultA1 = cellA1.Value;
                object resultR1C1 = cellR1C1.Value;

                // Output the results
                Console.WriteLine("Calculated Results:");
                Console.WriteLine("A1 = " + resultA1);
                Console.WriteLine("R1C1 = " + resultR1C1);

                // Save the presentation
                presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}