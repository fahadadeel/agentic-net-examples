class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide in the presentation
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a bubble chart to the slide (position and size are in points)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50, 50, 500, 400);

        // Access the series group of the first series in the chart
        Aspose.Slides.Charts.IChartSeriesGroup seriesGroup = chart.ChartData.Series[0].ParentSeriesGroup;

        // Set the bubble size scaling factor (e.g., 150% of the default size)
        seriesGroup.BubbleSizeScale = 150;

        // Optionally, define how bubble sizes are represented (Area or Width)
        seriesGroup.BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Area;

        // Save the presentation to disk
        presentation.Save("BubbleChartSizeScaling.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}