using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

            // Ensure the chart has a legend
            chart.HasLegend = true;

            // Set the legend position to the right side of the chart
            chart.Legend.Position = LegendPositionType.Right;

            // Optionally adjust legend size (fraction of chart dimensions)
            chart.Legend.Height = 0.2f; // 20% of chart height
            chart.Legend.Width = 0.2f;  // 20% of chart width

            // Save the presentation to a file
            presentation.Save("LegendPositionDemo.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}