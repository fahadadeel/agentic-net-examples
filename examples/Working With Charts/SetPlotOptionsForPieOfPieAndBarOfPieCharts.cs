using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a Pie of Pie chart
                IChart pieOfPieChart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 400, 300);
                // Configure the chart data
                IChartDataWorkbook workbook = pieOfPieChart.ChartData.ChartDataWorkbook;
                // Clear default series and categories
                pieOfPieChart.ChartData.Series.Clear();
                pieOfPieChart.ChartData.Categories.Clear();

                // Add categories
                pieOfPieChart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                pieOfPieChart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                pieOfPieChart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

                // Add a series
                IChartSeries series = pieOfPieChart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.PieOfPie);
                // Populate series data
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 40));
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 30));
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 30));

                // Set second plot options via the series group (read/write property)
                IChartSeriesGroup seriesGroup = pieOfPieChart.ChartData.SeriesGroups[0];
                seriesGroup.SecondPieSize = 150; // 150% of the first pie size
                seriesGroup.PieSplitBy = PieSplitType.ByValue; // Split by value
                seriesGroup.PieSplitPosition = 25; // Values less than 25 go to second pie

                // Add a Bar of Pie chart
                IChart barOfPieChart = slide.Shapes.AddChart(ChartType.BarOfPie, 50, 400, 400, 300);
                // Configure the chart data
                IChartDataWorkbook workbook2 = barOfPieChart.ChartData.ChartDataWorkbook;
                // Clear default series and categories
                barOfPieChart.ChartData.Series.Clear();
                barOfPieChart.ChartData.Categories.Clear();

                // Add categories
                barOfPieChart.ChartData.Categories.Add(workbook2.GetCell(0, 1, 0, "Category X"));
                barOfPieChart.ChartData.Categories.Add(workbook2.GetCell(0, 2, 0, "Category Y"));
                barOfPieChart.ChartData.Categories.Add(workbook2.GetCell(0, 3, 0, "Category Z"));

                // Add a series
                IChartSeries series2 = barOfPieChart.ChartData.Series.Add(workbook2.GetCell(0, 0, 1, "Series 1"), ChartType.BarOfPie);
                // Populate series data
                series2.DataPoints.AddDataPointForBarSeries(workbook2.GetCell(0, 1, 1, 50));
                series2.DataPoints.AddDataPointForBarSeries(workbook2.GetCell(0, 2, 1, 20));
                series2.DataPoints.AddDataPointForBarSeries(workbook2.GetCell(0, 3, 1, 30));

                // Set second plot options via the series group
                IChartSeriesGroup seriesGroup2 = barOfPieChart.ChartData.SeriesGroups[0];
                seriesGroup2.SecondPieSize = 120; // 120% of the first pie size
                seriesGroup2.PieSplitBy = PieSplitType.ByPercentage; // Split by percentage
                seriesGroup2.PieSplitPosition = 15; // Percent less than 15 go to second bar

                // Save the presentation
                pres.Save("SecondPlotOptions.pptx", SaveFormat.Pptx);
            }
        }
    }
}