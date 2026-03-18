using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a scatter chart without sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ScatterWithMarkers,
                50, 50, 500, 400, false);

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            int defaultWorksheetIndex = 0;
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                Aspose.Slides.Charts.ChartType.ScatterWithMarkers);
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
                Aspose.Slides.Charts.ChartType.ScatterWithMarkers);

            // Add categories (optional for scatter)
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate series1 data points
            series1.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, 1.0),
                workbook.GetCell(defaultWorksheetIndex, 1, 2, 4.0));
            series1.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 2.0),
                workbook.GetCell(defaultWorksheetIndex, 2, 2, 5.0));
            series1.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 3.0),
                workbook.GetCell(defaultWorksheetIndex, 3, 2, 6.0));

            // Populate series2 data points
            series2.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, 1.5),
                workbook.GetCell(defaultWorksheetIndex, 1, 3, 3.5));
            series2.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 2.5),
                workbook.GetCell(defaultWorksheetIndex, 2, 3, 4.5));
            series2.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 3.5),
                workbook.GetCell(defaultWorksheetIndex, 3, 3, 5.5));

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Scatter Chart Example");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chart.ChartTitle.Height = 20;

            // Configure axes titles
            Aspose.Slides.Charts.IAxis horizontalAxis = chart.Axes.HorizontalAxis;
            Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
            horizontalAxis.Title.AddTextFrameForOverriding("X Axis");
            verticalAxis.Title.AddTextFrameForOverriding("Y Axis");

            // Save the presentation
            pres.Save("ScatterChartExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}