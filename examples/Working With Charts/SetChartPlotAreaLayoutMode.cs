using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);

        // Set the layout mode of the chart's plot area to Inner
        chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

        // Save the presentation
        presentation.Save("ChartLayoutMode.pptx", SaveFormat.Pptx);
    }
}