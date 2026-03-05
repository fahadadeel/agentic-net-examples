using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Get the chart data range
        System.String dataRange = chart.ChartData.GetRange();
        System.Console.WriteLine("Chart data range: " + dataRange);

        // Iterate through chart series and output their names
        Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;
        for (int i = 0; i < seriesCollection.Count; i++)
        {
            Aspose.Slides.Charts.IChartSeries series = seriesCollection[i];
            Aspose.Slides.Charts.IStringChartValue seriesName = (Aspose.Slides.Charts.IStringChartValue)series.Name;
            System.Console.WriteLine("Series " + i + " name: " + seriesName.ToString());
        }

        // Save the presentation
        System.String outPath = System.IO.Path.Combine(
            System.IO.Directory.GetCurrentDirectory(),
            "ChartEntitiesOverview.pptx");
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}