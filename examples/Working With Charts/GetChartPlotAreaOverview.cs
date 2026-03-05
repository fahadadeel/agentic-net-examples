using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "";
            string outputPath = "ChartPlotAreaOverview.pptx";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a clustered column chart to the first slide
            Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(
                ChartType.ClusteredColumn,
                100f,   // X position
                100f,   // Y position
                500f,   // Width
                350f    // Height
            );

            // Calculate actual layout values for the chart
            chart.ValidateChartLayout();

            // Retrieve actual plot area dimensions
            double plotX = chart.PlotArea.ActualX;
            double plotY = chart.PlotArea.ActualY;
            double plotWidth = chart.PlotArea.ActualWidth;
            double plotHeight = chart.PlotArea.ActualHeight;

            // (Optional) Use the obtained values, e.g., write to console
            Console.WriteLine($"Plot Area - X: {plotX}, Y: {plotY}, Width: {plotWidth}, Height: {plotHeight}");

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}