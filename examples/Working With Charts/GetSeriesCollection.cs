using System;
using System.Drawing;
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

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

        // Get the series collection from the chart
        Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;

        // Iterate through each series in the collection
        for (int i = 0; i < seriesCollection.Count; i++)
        {
            Aspose.Slides.Charts.IChartSeries series = seriesCollection[i];

            // Set a solid fill color for the series
            series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series.Format.Fill.SolidFillColor.Color = Color.Blue;
        }

        // Save the presentation to a file
        presentation.Save("SeriesCollection.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}