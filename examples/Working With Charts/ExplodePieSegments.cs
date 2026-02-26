using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie,
            50f,   // X position
            50f,   // Y position
            400f,  // Width
            400f   // Height
        );

        // Access the first series (sample data already added)
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Explode the second slice (index 1) by 30%
        series.DataPoints[1].Explosion = 30;

        // Save the presentation
        presentation.Save("ExplodedPieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}