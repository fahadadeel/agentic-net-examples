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
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);

            // Set the plot area layout mode to inner (inside the chart area)
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

            // Save the presentation
            presentation.Save("ChartPlotAreaLayout.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}