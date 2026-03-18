using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Add a bubble chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f, true);

                // Access the chart's data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                // Add categories (required for bubble chart)
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Create bubble size cells
                Aspose.Slides.Charts.IChartDataCell sizeCell1 = workbook.GetCell(0, 0, 2, 30.0);
                Aspose.Slides.Charts.IChartDataCell sizeCell2 = workbook.GetCell(0, 0, 3, 50.0);
                Aspose.Slides.Charts.IChartDataCell sizeCell3 = workbook.GetCell(0, 0, 4, 70.0);

                // Add data points (X, Y, BubbleSize)
                series.DataPoints.AddDataPointForBubbleSeries(10.0, 20.0, sizeCell1);
                series.DataPoints.AddDataPointForBubbleSeries(15.0, 25.0, sizeCell2);
                series.DataPoints.AddDataPointForBubbleSeries(20.0, 30.0, sizeCell3);

                // Show bubble size values as data labels
                series.Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

                // Save the presentation
                string outputPath = "BubbleChart.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}