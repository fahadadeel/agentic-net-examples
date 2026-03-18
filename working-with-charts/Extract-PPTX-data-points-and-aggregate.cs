using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExtractChartData
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Dictionary to hold aggregated sums per chart title (or index)
                    Dictionary<string, double> chartSums = new Dictionary<string, double>();

                    int chartIndex = 0;
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            if (shape is Aspose.Slides.Charts.IChart)
                            {
                                Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)shape;
                                string chartKey = "Chart_" + chartIndex;
                                double totalSum = 0.0;

                                // Ensure the data source type is set to literals for values
                                foreach (Aspose.Slides.Charts.IChartSeries series in chart.ChartData.Series)
                                {
                                    series.DataPoints.DataSourceTypeForValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

                                    foreach (Aspose.Slides.Charts.IChartDataPoint dataPoint in series.DataPoints)
                                    {
                                        Aspose.Slides.Charts.IDoubleChartValue value = dataPoint.Value as Aspose.Slides.Charts.IDoubleChartValue;
                                        if (value != null)
                                        {
                                            double numericValue = value.AsLiteralDouble;
                                            totalSum += numericValue;
                                        }
                                    }
                                }

                                chartSums.Add(chartKey, totalSum);
                                chartIndex++;
                            }
                        }
                    }

                    // Output aggregated results
                    foreach (KeyValuePair<string, double> entry in chartSums)
                    {
                        Console.WriteLine($"{entry.Key}: Sum of values = {entry.Value}");
                    }

                    // Save the presentation (even if unchanged) before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}