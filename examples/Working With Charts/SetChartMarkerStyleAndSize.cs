using System;
using System.Drawing;

namespace ChartMarkerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Line, 50, 50, 500, 400);

            // Access the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories
            int defaultWorksheetIndex = 0;
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                Aspose.Slides.Charts.ChartType.Line);

            // Add data points to the series
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 15));

            // Set marker style and size for the entire series
            Aspose.Slides.Charts.IMarker seriesMarker = series.Marker;
            seriesMarker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;
            seriesMarker.Size = 12;

            // Set marker style and size for the first data point
            Aspose.Slides.Charts.IChartDataPoint firstPoint = series.DataPoints[0];
            Aspose.Slides.Charts.IMarker pointMarker = firstPoint.Marker;
            pointMarker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Square;
            pointMarker.Size = 8;

            // Save the presentation
            presentation.Save("ChartMarkerExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}