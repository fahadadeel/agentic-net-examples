using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Validate the chart layout
        chart.ValidateChartLayout();

        // Enable and set the chart title
        chart.HasTitle = true;
        Aspose.Slides.Charts.IChartTitle chartTitle = chart.ChartTitle;
        chartTitle.AddTextFrameForOverriding("Sample Chart Title");
        chartTitle.Height = 20f;

        // Enable and configure the legend
        chart.HasLegend = true;
        Aspose.Slides.Charts.ILegend legend = chart.Legend;
        legend.X = 0.8f;      // Position X as a fraction of chart width
        legend.Y = 0.1f;      // Position Y as a fraction of chart height
        legend.Width = 0.2f;  // Width as a fraction of chart width
        legend.Height = 0.2f; // Height as a fraction of chart height

        // Save the presentation
        pres.Save("AddLegendAndTitle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}