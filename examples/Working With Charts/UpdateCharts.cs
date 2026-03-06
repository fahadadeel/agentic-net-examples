using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve the first chart on the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;

        // Set an external workbook as the data source and update chart data
        ((Aspose.Slides.Charts.ChartData)chart.ChartData).SetExternalWorkbook("data.xlsx", true);

        // Recalculate any formulas in the embedded workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        workbook.CalculateFormulas();

        // Save the updated presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}