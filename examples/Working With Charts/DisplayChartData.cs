public class Program
{
    public static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a stacked column chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.StackedColumn,
            50f,   // X position
            50f,   // Y position
            500f,  // Width
            400f   // Height
        );

        // Enable display of values and percentages on data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

        // Save the presentation
        presentation.Save("DisplayChartData_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}