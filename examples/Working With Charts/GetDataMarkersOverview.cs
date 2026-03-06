using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart with markers
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.LineWithMarkers, 0f, 0f, 400f, 400f);

        int defaultWorksheetIndex = 0;
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Remove the default generated series
        chart.ChartData.Series.Clear();

        // Add a new series
        chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"),
            chart.Type);

        // Load images to be used as markers
        Aspose.Slides.IImage img1 = Aspose.Slides.Images.FromFile("image1.png");
        Aspose.Slides.IPPImage imgx1 = presentation.Images.AddImage(img1);
        Aspose.Slides.IImage img2 = Aspose.Slides.Images.FromFile("image2.png");
        Aspose.Slides.IPPImage imgx2 = presentation.Images.AddImage(img2);

        // Get the series we just added
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Add data points with picture markers
        Aspose.Slides.Charts.IChartDataPoint point1 = series.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
        point1.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
        point1.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

        Aspose.Slides.Charts.IChartDataPoint point2 = series.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
        point2.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
        point2.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

        Aspose.Slides.Charts.IChartDataPoint point3 = series.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
        point3.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
        point3.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

        Aspose.Slides.Charts.IChartDataPoint point4 = series.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 4, 1, 40));
        point4.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Picture;
        point4.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

        // Set marker size for the series
        series.Marker.Size = 10;

        // Save the presentation
        presentation.Save("DataMarkersOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}