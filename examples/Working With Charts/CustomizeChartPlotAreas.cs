using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 600f, 400f);

        // Customize the plot area layout
        chart.PlotArea.AsILayoutable.X = 0.1f; // 10% from left
        chart.PlotArea.AsILayoutable.Y = 0.1f; // 10% from top
        chart.PlotArea.AsILayoutable.Width = 0.8f; // 80% width
        chart.PlotArea.AsILayoutable.Height = 0.8f; // 80% height

        // Set layout target type to Inner (inside)
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

        // Validate layout (optional, to compute actual values)
        chart.ValidateChartLayout();

        // Save the presentation
        presentation.Save("CustomizedPlotArea.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}