using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a doughnut chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50, 50, 500, 400);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Worksheet index
            int defaultWorksheetIndex = 0;
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Product A"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Product B"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Product C"));

            // Add data points for the doughnut series
            Aspose.Slides.Charts.IChartDataPoint dp1 = series.DataPoints.AddDataPointForDoughnutSeries(30);
            Aspose.Slides.Charts.IChartDataPoint dp2 = series.DataPoints.AddDataPointForDoughnutSeries(50);
            Aspose.Slides.Charts.IChartDataPoint dp3 = series.DataPoints.AddDataPointForDoughnutSeries(20);

            // Enable callout for all data labels in the series
            series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Customize the callout for the second data point (highlight)
            dp2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            dp2.Format.Fill.SolidFillColor.Color = Color.Red;

            dp2.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            dp2.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;

            // Set text formatting for the callout label
            Aspose.Slides.Charts.IDataLabel label2 = dp2.Label;
            label2.DataLabelFormat.ShowValue = true;
            label2.DataLabelFormat.TextFormat.PortionFormat.FontHeight = 14f;
            label2.DataLabelFormat.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

            // Save the presentation
            pres.Save("DoughnutCallout.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}