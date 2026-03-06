using System;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a doughnut chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Doughnut, 50, 50, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get default worksheet index
            int defaultWorksheetIndex = 0;
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add data points for the doughnut series
            series.DataPoints.AddDataPointForDoughnutSeries(20);
            series.DataPoints.AddDataPointForDoughnutSeries(30);
            series.DataPoints.AddDataPointForDoughnutSeries(50);

            // Set the doughnut hole size (center gap) to 50%
            Aspose.Slides.Charts.IChartSeriesGroup seriesGroup = series.ParentSeriesGroup;
            seriesGroup.DoughnutHoleSize = (byte)50;

            // Save the presentation
            presentation.Save("DoughnutChartCenterGap.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}