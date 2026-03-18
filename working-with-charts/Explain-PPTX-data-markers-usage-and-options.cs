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
            // Create a new presentation
            using (var pres = new Presentation())
            {
                // Access the first slide
                var slide = pres.Slides[0];

                // Add a scatter chart with markers
                var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 50, 50, 500, 400);

                // Get the chart data workbook
                var defaultWorksheetIndex = 0;
                var chartDataWorkbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a series
                var series = chart.ChartData.Series.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

                // Add categories (X axis labels)
                chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 0, "A"));
                chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 0, "B"));
                chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 0, "C"));

                // Add data points (X, Y values)
                series.DataPoints.AddDataPointForScatterSeries(1.0, chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
                series.DataPoints.AddDataPointForScatterSeries(2.0, chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
                series.DataPoints.AddDataPointForScatterSeries(3.0, chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                // Configure marker for the first data point
                var dp0 = series.DataPoints[0];
                dp0.Marker.Symbol = MarkerStyleType.Circle;
                dp0.Marker.Size = 10;
                dp0.Marker.Format.Fill.FillType = FillType.Solid;
                dp0.Marker.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Red;

                // Configure marker for the second data point
                var dp1 = series.DataPoints[1];
                dp1.Marker.Symbol = MarkerStyleType.Square;
                dp1.Marker.Size = 12;
                dp1.Marker.Format.Fill.FillType = FillType.Solid;
                dp1.Marker.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Green;

                // Configure marker for the third data point
                var dp2 = series.DataPoints[2];
                dp2.Marker.Symbol = MarkerStyleType.Triangle;
                dp2.Marker.Size = 14;
                dp2.Marker.Format.Fill.FillType = FillType.Solid;
                dp2.Marker.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Blue;

                // Save the presentation
                pres.Save("DataMarkersDemo.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}