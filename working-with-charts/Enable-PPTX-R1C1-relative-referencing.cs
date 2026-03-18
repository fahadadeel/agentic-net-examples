using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            // Add a simple table
            double[] columnWidths = { 100, 100 };
            double[] rowHeights = { 30, 30 };
            var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Add a chart to demonstrate R1C1-style formula usage
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 200, 50, 400, 300);
            var workbook = chart.ChartData.ChartDataWorkbook;

            // Set an R1C1 formula in a cell (e.g., B2) using relative addressing
            var cell = workbook.GetCell(0, "B2");
            cell.R1C1Formula = "SUM(R[-1]C:R[-1]C)";

            // Recalculate formulas
            workbook.CalculateFormulas();

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}