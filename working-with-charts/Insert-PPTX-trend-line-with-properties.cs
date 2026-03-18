using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var pres = new Presentation())
            {
                var slide = pres.Slides[0];
                // Add a clustered column chart
                var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
                // Access the first series
                var series = chart.ChartData.Series[0];
                // Add a linear trendline to the series
                var trendline = series.TrendLines.Add(TrendlineType.Linear);
                // Configure trendline properties
                trendline.DisplayEquation = true;
                trendline.DisplayRSquaredValue = true;
                trendline.TrendlineName = "Linear Trend";
                // Save the presentation
                pres.Save("TrendlineChart.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}