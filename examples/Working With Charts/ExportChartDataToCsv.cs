using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportChartDataToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");
            string csvPath = Path.Combine(dataDir, "chartdata.csv");

            // Load presentation
            Presentation pres = new Presentation(inputPath);

            // Get first slide and first chart
            ISlide slide = pres.Slides[0];
            IChart chart = slide.Shapes[0] as IChart;

            // Export chart data to CSV
            using (StreamWriter writer = new StreamWriter(csvPath, false, Encoding.UTF8))
            {
                for (int s = 0; s < chart.ChartData.Series.Count; s++)
                {
                    IChartSeries series = chart.ChartData.Series[s];
                    StringBuilder lineBuilder = new StringBuilder();

                    // Series identifier (you can replace with actual series name if available)
                    lineBuilder.Append("Series" + s);

                    for (int p = 0; p < series.DataPoints.Count; p++)
                    {
                        object rawValue = series.DataPoints[p].Value.Data;
                        string valueString;

                        IStringChartValue stringChartValue = rawValue as IStringChartValue;
                        if (stringChartValue != null)
                        {
                            // Convert IStringChartValue to string
                            valueString = stringChartValue.ToString();
                        }
                        else if (rawValue != null)
                        {
                            valueString = rawValue.ToString();
                        }
                        else
                        {
                            valueString = string.Empty;
                        }

                        lineBuilder.Append("," + valueString);
                    }

                    writer.WriteLine(lineBuilder.ToString());
                }
            }

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}