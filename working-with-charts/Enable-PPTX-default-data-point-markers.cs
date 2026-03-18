using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Collections.Generic;

namespace EnableDefaultMarkers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Presentation presentation = new Presentation())
                {
                    // Add a sample chart to the first slide (optional, ensures there is at least one chart)
                    IChart sampleChart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);
                    
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < presentation.Slides[slideIndex].Shapes.Count; shapeIndex++)
                        {
                            IChart chart = presentation.Slides[slideIndex].Shapes[shapeIndex] as IChart;
                            if (chart != null)
                            {
                                // Iterate through all series in the chart
                                for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                                {
                                    IChartSeries series = chart.ChartData.Series[seriesIndex];
                                    // Iterate through all data points in the series
                                    for (int pointIndex = 0; pointIndex < series.DataPoints.Count; pointIndex++)
                                    {
                                        IChartDataPoint dataPoint = series.DataPoints[pointIndex];
                                        // Enable default marker style and size
                                        dataPoint.Marker.Symbol = MarkerStyleType.Circle;
                                        dataPoint.Marker.Size = 5;
                                    }
                                }
                            }
                        }
                    }

                    // Save the presentation
                    presentation.Save("Output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}