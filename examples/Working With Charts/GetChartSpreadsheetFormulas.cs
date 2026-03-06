using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartSpreadsheetFormulasDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Get the workbook associated with the chart
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Populate cells B2 and B3 with numeric values
            workbook.GetCell(0, "B2", 2);
            workbook.GetCell(0, "B3", 3);

            // Set a formula in cell B4 that adds B2 and B3
            workbook.GetCell(0, "B4").Formula = "B2+B3";

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Save the presentation
            presentation.Save("ChartFormulas_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}