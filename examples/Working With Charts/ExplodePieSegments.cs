// Console application demonstrating exploding a pie chart slice using Aspose.Slides
class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide (index 0)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide at position (50,50) with size 400x400 points
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie,
            50f, 50f, 400f, 400f);

        // Retrieve the first series of the chart (index 0)
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Explode the first data point (slice) by 20% of the pie diameter
        series.DataPoints[0].Explosion = 20;

        // Save the presentation to a PPTX file
        presentation.Save("ExplodePieSegments_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}