using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add a line chart to the slide
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 500, 400);

        // Access the first series of the chart
        var series = chart.ChartData.Series[0];

        // Set marker size and style for the series
        series.Marker.Size = 10;
        series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;

        // Set marker size and style for each data point in the series
        foreach (var dataPoint in series.DataPoints)
        {
            dataPoint.Marker.Size = 12;
            dataPoint.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Square;
        }

        // Save the presentation to a file
        presentation.Save("DataMarkersOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}