using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a chart to the first slide
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Define the data source type for the chart's first series values as double literals
                IChartSeries series = chart.ChartData.Series[0];
                series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;

                // Optionally, add some data points
                series.DataPoints.Clear();
                series.DataPoints.AddDataPointForBarSeries(10);
                series.DataPoints.AddDataPointForBarSeries(20);
                series.DataPoints.AddDataPointForBarSeries(30);

                // Save the presentation
                presentation.Save("DataSourceTypeExample.pptx", SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}