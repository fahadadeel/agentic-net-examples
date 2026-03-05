using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50, 50, 500, 400);

        // Access the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Add a linear trendline to the series
        Aspose.Slides.Charts.ITrendline trendline = series.TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Linear);
        trendline.DisplayEquation = true;
        trendline.DisplayRSquaredValue = true;

        // Save the presentation
        presentation.Save("TrendLinesOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}