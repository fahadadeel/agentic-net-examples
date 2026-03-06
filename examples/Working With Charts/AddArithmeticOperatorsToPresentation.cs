using System;

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

        // Get the chart's data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Populate cells with numeric values
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);

        // Set a formula that adds the two cells (arithmetic operator)
        workbook.GetCell(0, "B4").Formula = "B2+B3";

        // Calculate the formula result
        workbook.CalculateFormulas();

        // Save the presentation (fully qualified SaveFormat)
        presentation.Save("ArithmeticOperators_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}