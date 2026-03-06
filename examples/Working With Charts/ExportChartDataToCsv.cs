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
            string csvPath = Path.Combine(dataDir, "chartData.csv");

            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Get first shape as chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

            if (chart != null)
            {
                // Get chart data range (optional, just to demonstrate usage)
                string range = chart.ChartData.GetRange();

                // Prepare CSV content
                StringBuilder csvBuilder = new StringBuilder();

                // Write header row (Series names)
                for (int s = 0; s < chart.ChartData.Series.Count; s++)
                {
                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[s];
                    csvBuilder.Append(series.Name);
                    if (s < chart.ChartData.Series.Count - 1)
                        csvBuilder.Append(",");
                }
                csvBuilder.AppendLine();

                // Determine maximum number of data points among all series
                int maxPoints = 0;
                for (int s = 0; s < chart.ChartData.Series.Count; s++)
                {
                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[s];
                    if (series.DataPoints.Count > maxPoints)
                        maxPoints = series.DataPoints.Count;
                }

                // Write data rows
                for (int i = 0; i < maxPoints; i++)
                {
                    for (int s = 0; s < chart.ChartData.Series.Count; s++)
                    {
                        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[s];
                        if (i < series.DataPoints.Count)
                        {
                            Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints[i];
                            object valueObj = point.Value.Data;
                            string valueStr = valueObj != null ? valueObj.ToString() : "";
                            csvBuilder.Append(valueStr);
                        }
                        // If this series has fewer points, leave empty cell
                        if (s < chart.ChartData.Series.Count - 1)
                            csvBuilder.Append(",");
                    }
                    csvBuilder.AppendLine();
                }

                // Save CSV file
                using (StreamWriter writer = new StreamWriter(csvPath, false, Encoding.UTF8))
                {
                    writer.Write(csvBuilder.ToString());
                }
            }

            // Save the presentation (required by lifecycle rules)
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}