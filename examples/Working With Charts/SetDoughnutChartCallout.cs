using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a doughnut chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Doughnut,
            0f, 0f, 500f, 400f);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workBook.GetCell(0, 0, 1, "Series 1"),
            chart.Type);

        // Add a category
        chart.ChartData.Categories.Add(
            workBook.GetCell(0, 1, 0, "Category 1"));

        // Add a data point for the doughnut series
        Aspose.Slides.Charts.IChartDataPoint dataPoint = series.DataPoints.AddDataPointForDoughnutSeries(
            workBook.GetCell(0, 1, 1, 30));

        // Set fill and line formatting for the data point
        dataPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        dataPoint.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        dataPoint.Format.Line.Style = Aspose.Slides.LineStyle.Single;
        dataPoint.Format.Line.DashStyle = Aspose.Slides.LineDashStyle.Solid;

        // Configure the data label as a callout
        Aspose.Slides.Charts.IDataLabel lbl = dataPoint.Label;
        lbl.TextFormat.TextBlockFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;
        lbl.DataLabelFormat.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
        lbl.DataLabelFormat.TextFormat.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial");
        lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;

        // Save the presentation
        pres.Save("DoughnutCallout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}