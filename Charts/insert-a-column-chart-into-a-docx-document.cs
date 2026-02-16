using System;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Drawing.Charts;

class InsertColumnChart
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a column chart (width: 500 points, height: 300 points).
        Shape chartShape = builder.InsertChart(ChartType.Column, 500, 300);
        Chart chart = chartShape.Chart;

        // Remove the default demo series.
        chart.Series.Clear();

        // Define categories for the X‑axis.
        string[] categories = { "Q1", "Q2", "Q3", "Q4" };

        // Add two data series with values for each category.
        chart.Series.Add("Revenue", categories, new double[] { 15000, 21000, 18000, 24000 });
        chart.Series.Add("Expenses", categories, new double[] { 8000, 9500, 7000, 11000 });

        // Set a title for the chart.
        chart.Title.Text = "Annual Financial Overview";
        chart.Title.Show = true;
        chart.Title.Font.Size = 14;
        chart.Title.Font.Color = Color.DarkBlue;

        // Save the document to a DOCX file.
        doc.Save("ColumnChart.docx");
    }
}
