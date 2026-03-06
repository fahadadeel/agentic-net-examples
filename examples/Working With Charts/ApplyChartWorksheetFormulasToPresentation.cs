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

            // Set values for cells B2 and B3
            workbook.GetCell(0, "B2", 2);
            workbook.GetCell(0, "B3", 3);

            // Set a formula for cell B4 that adds B2 and B3
            workbook.GetCell(0, "B4").Formula = "B2+B3";

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Define output file path
            string outPath = Path.Combine(Directory.GetCurrentDirectory(), "ChartWorksheetFormulas_out.pptx");

            // Save the presentation
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}