using System;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Drawing.Charts;

class InsertChartExample
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();

        // Initialize DocumentBuilder for the document.
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a Bar chart with the specified width and height.
        // The InsertChart method returns a Shape that contains the chart.
        Shape chartShape = builder.InsertChart(ChartType.Bar, 400, 300);

        // Access the Chart object from the shape.
        Chart chart = chartShape.Chart;

        // Set a title for the chart.
        ChartTitle title = chart.Title;
        title.Text = "Sales Overview";
        title.Font.Size = 14;
        title.Font.Color = Color.DarkBlue;
        title.Show = true;          // Ensure the title is visible.
        title.Overlay = false;      // Do not allow other elements to overlap the title.

        // Optionally, change the chart style.
        chart.Style = ChartStyle.Shaded;

        // Clear the default demo series.
        chart.Series.Clear();

        // Define categories and values for a new series.
        string[] categories = { "Q1", "Q2", "Q3", "Q4" };
        double[] values = { 15000, 21000, 18000, 24000 };

        // Add the series to the chart.
        chart.Series.Add("Revenue", categories, values);

        // Save the document to a DOCX file.
        doc.Save("ChartInserted.docx");
    }
}
