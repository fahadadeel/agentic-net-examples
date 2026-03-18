using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Assume the first shape is a chart
                IChart chart = (IChart)slide.Shapes[0];

                // Verify the chart is a doughnut type
                if (ChartTypeCharacterizer.IsChartTypeDoughnut(chart.Type))
                {
                    // Set the doughnut hole size via the series group (read‑write)
                    chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = 50; // 50 %

                    // Enable automatic varied colors for all series
                    foreach (IChartSeries series in chart.ChartData.Series)
                    {
                        series.ParentSeriesGroup.IsColorVaried = true;
                    }

                    // Add a new series to the chart
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    int defaultWorksheetIndex = 0;
                    IChartDataCell seriesNameCell = workbook.GetCell(defaultWorksheetIndex, 0, 3, "New Series");
                    IChartSeries newSeries = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

                    // Populate the new series with doughnut data points
                    newSeries.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 1, 3, 40));
                    newSeries.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 2, 3, 30));
                    newSeries.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 3, 3, 30));
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}