using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Get the series collection from the chart
        Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;

        // Output the number of series in the chart
        int seriesCount = seriesCollection.Count;
        Console.WriteLine("Series count: " + seriesCount);

        // Save the presentation
        presentation.Save("GetChartSeries_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}