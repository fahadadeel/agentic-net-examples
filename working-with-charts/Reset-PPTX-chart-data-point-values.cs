using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartDataPointReset
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load the presentation
                var presentationPath = "input.pptx";
                using (var presentation = new Presentation(presentationPath))
                {
                    // Iterate through all slides
                    foreach (var slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (var shape in slide.Shapes)
                        {
                            // Check if the shape is a chart
                            if (shape is IChart chart)
                            {
                                // Iterate through each series in the chart
                                foreach (var series in chart.ChartData.Series)
                                {
                                    // Ensure there is at least one data point
                                    if (series.DataPoints.Count > 0)
                                    {
                                        // Remove the first data point from the series
                                        var dataPoint = series.DataPoints[0];
                                        dataPoint.Remove();
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    var outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}