using System;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered bar chart without sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredBar,
                50f, 50f, 500f, 400f, false);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Comparison");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chart.ChartTitle.Height = 20f;

            // Access chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "2019"), chart.Type);
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 2, "2020"), chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 4, 0, "Q4"));

            // Populate series1 data
            series1.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, 150));
            series1.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 200));
            series1.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 180));
            series1.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 4, 1, 220));

            // Set fill color for series1
            series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series1.Format.Fill.SolidFillColor.Color = Color.Red;

            // Populate series2 data
            series2.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 2, 130));
            series2.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 2, 170));
            series2.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 2, 160));
            series2.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 4, 2, 210));

            // Set fill color for series2
            series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series2.Format.Fill.SolidFillColor.Color = Color.Green;

            // Show values for the first data point of each series
            series1.DataPoints[0].Label.DataLabelFormat.ShowValue = true;
            series2.DataPoints[0].Label.DataLabelFormat.ShowValue = true;

            // Save the presentation
            pres.Save("BarChartPresentation.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}