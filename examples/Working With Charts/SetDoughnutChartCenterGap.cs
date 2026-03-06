using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a doughnut chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Doughnut,
            50f, 50f, 500f, 400f);

        // Access the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Set the center gap (hole size) to 50 percent
        series.ParentSeriesGroup.DoughnutHoleSize = 50;

        // Save the presentation
        presentation.Save("DoughnutChartCenterGap.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}