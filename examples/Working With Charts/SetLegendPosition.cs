using System;

namespace SetLegendPosition
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

            // Position and size the legend using fractional coordinates
            chart.Legend.X = 0.5f;      // 50% of chart width from left
            chart.Legend.Y = 0.5f;      // 50% of chart height from top
            chart.Legend.Width = 0.2f;  // 20% of chart width
            chart.Legend.Height = 0.2f; // 20% of chart height

            // Save the presentation
            presentation.Save("SetLegendPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}