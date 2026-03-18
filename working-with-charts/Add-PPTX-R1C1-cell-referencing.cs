using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

namespace R1C1CellReferenceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f,
                    50f,
                    500f,
                    400f);

                // Access the chart's workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Retrieve a cell (row 0, column 0) from the first worksheet
                Aspose.Slides.Charts.IChartDataCell cell = workbook.GetCell(0, 0, 0);

                // Set an R1C1‑style formula for the cell
                cell.R1C1Formula = "SUM(R2C1:R5C1)";

                // Recalculate formulas to update values
                workbook.CalculateFormulas();

                // Save the presentation
                presentation.Save("R1C1Table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Aspose.Slides.Spreadsheet.CellInvalidReferenceException ex)
            {
                Console.WriteLine("Invalid cell reference: " + ex.Reference);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}