using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetMarkerFillBorderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line chart with markers
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.LineWithMarkers,
                0f, 0f, 400f, 400f);

            // Index of the default worksheet
            int defaultWorksheetIndex = 0;

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a new series
            chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);

            // Get the added series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Add data points to the series
            series.DataPoints.AddDataPointForLineSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            series.DataPoints.AddDataPointForLineSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            series.DataPoints.AddDataPointForLineSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
            series.DataPoints.AddDataPointForLineSeries(
                workbook.GetCell(defaultWorksheetIndex, 4, 1, 40));

            // Customize marker fill and border for each data point
            for (int i = 0; i < series.DataPoints.Count; i++)
            {
                Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints[i];

                // Set solid fill color for the marker
                point.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                point.Marker.Format.Fill.SolidFillColor.Color = Color.Red;

                // Set border (line) for the marker
                point.Marker.Format.Line.Width = 2.0;
                point.Marker.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                point.Marker.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
            }

            // Optionally set marker size for the series
            series.Marker.Size = 12;

            // Save the presentation
            presentation.Save("SetMarkerFillBorder_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}