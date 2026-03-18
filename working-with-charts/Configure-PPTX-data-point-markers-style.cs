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
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 500, 400);

            // Index of the default worksheet
            int defaultWorksheetIndex = 0;
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add a series
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

            // Add data points to the series
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 15));

            // Customize marker style, size, and visibility for each data point
            IChartDataPoint point0 = series.DataPoints[0];
            point0.Marker.Symbol = MarkerStyleType.Circle;
            point0.Marker.Size = 12; // larger marker

            IChartDataPoint point1 = series.DataPoints[1];
            point1.Marker.Symbol = MarkerStyleType.Square;
            point1.Marker.Size = 16; // even larger marker

            IChartDataPoint point2 = series.DataPoints[2];
            point2.Marker.Symbol = MarkerStyleType.None; // hide marker
            point2.Marker.Size = 0;

            // Save the presentation
            presentation.Save("ChartMarkerSettings.pptx", SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}