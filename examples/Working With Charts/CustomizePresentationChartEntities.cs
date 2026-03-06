using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Enable and configure the chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
        chart.ChartTitle.Height = 20f;

        // Prepare the chart data workbook
        int defaultWorksheetIndex = 0;
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Remove the default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add two series
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "2019"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "2020"), chart.Type);

        // Add three categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));

        // Populate data for the first series
        Aspose.Slides.Charts.IChartSeries series0 = chart.ChartData.Series[0];
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 150));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 200));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 250));

        // Set fill color for the first series
        series0.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series0.Format.Fill.SolidFillColor.Color = Color.Blue;

        // Populate data for the second series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[1];
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 180));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 220));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 260));

        // Set fill color for the second series
        series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series1.Format.Fill.SolidFillColor.Color = Color.Green;

        // Show data labels for the first series
        series0.DataPoints[0].Label.DataLabelFormat.ShowValue = true;
        series0.DataPoints[1].Label.DataLabelFormat.ShowValue = true;
        series0.DataPoints[2].Label.DataLabelFormat.ShowValue = true;

        // Save the presentation
        presentation.Save("CustomizedChart.pptx", SaveFormat.Pptx);
    }
}