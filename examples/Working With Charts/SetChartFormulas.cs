using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart at position (0,0) with size 500x400
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

        // Access the chart's embedded workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Set numeric values in cells B2 and B3
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);

        // Set a formula in cell B4 that adds B2 and B3
        workbook.GetCell(0, "B4").Formula = "B2+B3";

        // Calculate all formulas in the workbook
        workbook.CalculateFormulas();

        // Save the presentation to a PPTX file
        presentation.Save("SetChartFormulas_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}