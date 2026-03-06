using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a line chart to the first slide
        Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 500f, 400f);

        // Disable the horizontal axis
        chart.Axes.HorizontalAxis.IsVisible = false;

        // Save the presentation
        pres.Save("DisableHorizontalAxisLineChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}