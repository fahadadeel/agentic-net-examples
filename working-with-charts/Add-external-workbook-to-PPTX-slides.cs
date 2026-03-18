using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directory and external workbook file
            string dataDir = "Data";
            Directory.CreateDirectory(dataDir);
            string workbookPath = Path.Combine(dataDir, "workbook.xlsx");
            if (!File.Exists(workbookPath))
            {
                // Create an empty workbook file (placeholder)
                File.WriteAllBytes(workbookPath, new byte[0]);
            }

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a pie chart to the first slide
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 500);

            // Access chart data
            Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

            // Link the external workbook as data source
            ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath);

            // Populate series and categories using the workbook cells
            int defaultWorksheetIndex = 0;
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chartData.ChartDataWorkbook;
            chartData.Series.Clear();
            chartData.Categories.Clear();

            chartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            chartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

            chartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add data points for the first series
            Aspose.Slides.Charts.IChartSeries series0 = chartData.Series[0];
            series0.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            series0.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            series0.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Add data points for the second series
            Aspose.Slides.Charts.IChartSeries series1 = chartData.Series[1];
            series1.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
            series1.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));
            series1.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 35));

            // Save the presentation
            string outPath = Path.Combine(dataDir, "ExternalWorkbookChart.pptx");
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}