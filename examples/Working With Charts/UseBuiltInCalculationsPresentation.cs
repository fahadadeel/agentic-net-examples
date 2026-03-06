using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace UseBuiltInCalculationsPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 400f, 300f);

            // Access the chart's workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Set values in cells B2 and B3
            workbook.GetCell(0, "B2", 2);
            workbook.GetCell(0, "B3", 3);

            // Set a formula in cell B4 that adds B2 and B3
            workbook.GetCell(0, "B4").Formula = "B2+B3";

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Save the presentation
            presentation.Save("UseBuiltInCalculationsPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}