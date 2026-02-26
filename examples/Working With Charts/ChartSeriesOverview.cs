using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Get the series collection of the chart
        Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;

        // Iterate over each series and its data points
        foreach (Aspose.Slides.Charts.ChartSeries seriesItem in seriesCollection)
        {
            foreach (Aspose.Slides.Charts.IChartDataPoint dataPoint in seriesItem.DataPoints)
            {
                // Set the number format of the data point to percentage (preset 9 corresponds to "0%")
                dataPoint.Value.AsCell.PresetNumberFormat = 9; // 0%
            }
        }

        // Save the presentation to a PPTX file
        presentation.Save("ChartSeriesOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}