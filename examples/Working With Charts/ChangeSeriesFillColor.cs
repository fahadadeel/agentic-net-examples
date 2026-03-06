using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50, 50, 500, 400);

        // Change fill color of the first series to Red
        chart.ChartData.Series[0].Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        chart.ChartData.Series[0].Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 0, 0);

        // Ensure a second series exists
        if (chart.ChartData.Series.Count < 2)
        {
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;
            chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 2"),
                chart.Type);
        }

        // Change fill color of the second series to Green
        chart.ChartData.Series[1].Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        chart.ChartData.Series[1].Format.Fill.SolidFillColor.Color = Color.FromArgb(0, 255, 0);

        // Save the presentation
        presentation.Save("ChangeSeriesFillColor_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}