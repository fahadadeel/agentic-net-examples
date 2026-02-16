using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Drawing.Charts;
using System.Drawing;

class InsertChartExample
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();

        // Initialize a DocumentBuilder for the document.
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a bar chart with the specified size.
        Shape chartShape = builder.InsertChart(ChartType.Bar, 400, 300);
        Chart chart = chartShape.Chart;

        // Set the chart title.
        ChartTitle title = chart.Title;
        title.Text = "Sales Overview";
        title.Font.Size = 14;
        title.Font.Color = Color.Blue;
        title.Show = true;
        title.Overlay = true;

        // Replace the default demo data with custom series.
        chart.Series.Clear();
        string[] categories = { "Q1", "Q2", "Q3", "Q4" };
        chart.Series.Add("2019", categories, new double[] { 120, 150, 180, 200 });
        chart.Series.Add("2020", categories, new double[] { 130, 160, 190, 210 });

        // Save the document as a DOCX file.
        doc.Save("ChartDocument.docx");
    }
}
