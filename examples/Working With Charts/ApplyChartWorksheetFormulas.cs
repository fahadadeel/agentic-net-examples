using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ApplyChartWorksheetFormulas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Access the chart's data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Set a formula in cell B4 (row 3, column 1) that adds B2 and B3
            workbook.GetCell(0, 3, 1).Formula = "B2+B3";

            // Set values for B2 (row 1, column 1) and B3 (row 2, column 1)
            workbook.GetCell(0, 1, 1).Value = 2;
            workbook.GetCell(0, 2, 1).Value = 3;

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Save the presentation
            string outPath = Path.Combine(Directory.GetCurrentDirectory(), "ChartWorksheetFormulas_out.pptx");
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}