using System;

namespace CustomizeChartLegend
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Customize legend position and size
            chart.Legend.X = 0.8f;      // X as fraction of chart width
            chart.Legend.Y = 0.1f;      // Y as fraction of chart height
            chart.Legend.Width = 0.2f;  // Width as fraction of chart width
            chart.Legend.Height = 0.2f; // Height as fraction of chart height

            // Save the presentation
            presentation.Save("CustomLegendChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}