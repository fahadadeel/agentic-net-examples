using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart with markers
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.LineWithMarkers, 0, 0, 400, 400);

        // Index of the default worksheet
        int defaultWorksheetIndex = 0;

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add a series
        chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
            chart.Type);
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 4, 0, "Category 4"));

        // Load marker images
        Aspose.Slides.IImage img1 = Aspose.Slides.Images.FromFile("marker1.png");
        Aspose.Slides.IPPImage imgx1 = presentation.Images.AddImage(img1);
        Aspose.Slides.IImage img2 = Aspose.Slides.Images.FromFile("marker2.png");
        Aspose.Slides.IPPImage imgx2 = presentation.Images.AddImage(img2);

        // Data point 1 with custom picture fill
        Aspose.Slides.Charts.IChartDataPoint point1 = series.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
        point1.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
        point1.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

        // Data point 2 with custom picture fill
        Aspose.Slides.Charts.IChartDataPoint point2 = series.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
        point2.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
        point2.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

        // Data point 3 with custom picture fill
        Aspose.Slides.Charts.IChartDataPoint point3 = series.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
        point3.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
        point3.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

        // Data point 4 with custom picture fill
        Aspose.Slides.Charts.IChartDataPoint point4 = series.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 4, 1, 40));
        point4.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
        point4.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

        // Set marker size for the series
        series.Marker.Size = 12;

        // Save the presentation
        presentation.Save("CustomMarkerChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}