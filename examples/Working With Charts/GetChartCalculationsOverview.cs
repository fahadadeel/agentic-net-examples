using System;

namespace ChartCalculationsOverview
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

            // Get the workbook that holds chart data
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Populate cells with numeric values
            workbook.GetCell(0, 1, 1).Value = 2; // Cell B2
            workbook.GetCell(0, 2, 1).Value = 3; // Cell B3

            // Set a formula that adds the two previous cells
            workbook.GetCell(0, 3, 1).Formula = "B2+B3"; // Cell B4

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Save the presentation to a PPTX file
            presentation.Save("ChartCalculationsOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}