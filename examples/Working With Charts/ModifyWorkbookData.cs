using System;

namespace ModifyWorkbookData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output path
            System.String outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ModifiedWorkbookData.pptx");
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);
            // Access the chart's workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            // Set values in cells B2 and B3
            workbook.GetCell(0, "B2", 2);
            workbook.GetCell(0, "B3", 3);
            // Set formula in B4 to sum B2 and B3
            Aspose.Slides.Charts.IChartDataCell cellB4 = workbook.GetCell(0, "B4");
            cellB4.Formula = "B2+B3";
            // Calculate formulas
            workbook.CalculateFormulas();
            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}