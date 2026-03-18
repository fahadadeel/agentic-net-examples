using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    var slide = presentation.Slides[0];

                    // Add a clustered column chart to the slide
                    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                    // Access the first series of the chart
                    var series = chart.ChartData.Series[0];

                    // Add a data point to the series (if none exists)
                    if (series.DataPoints.Count == 0)
                    {
                        series.DataPoints.AddDataPointForBarSeries(10);
                    }

                    // Access the first data point
                    var dataPoint = series.DataPoints[0];

                    // Set the position of the data label for the data point
                    dataPoint.Label.DataLabelFormat.Position = LegendDataLabelPosition.Bottom;

                    // Save the presentation
                    presentation.Save("ModifiedLabelPosition.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}