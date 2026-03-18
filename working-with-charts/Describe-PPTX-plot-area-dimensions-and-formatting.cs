using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Ensure layout calculations are performed
                chart.ValidateChartLayout();

                // Access the plot area
                IChartPlotArea plotArea = chart.PlotArea;

                // Retrieve actual layout values
                float actualX = plotArea.ActualX;
                float actualY = plotArea.ActualY;
                float actualWidth = plotArea.ActualWidth;
                float actualHeight = plotArea.ActualHeight;

                // Retrieve relative layout values
                float relativeX = plotArea.X;
                float relativeY = plotArea.Y;
                float relativeWidth = plotArea.Width;
                float relativeHeight = plotArea.Height;

                // Retrieve layout target type
                LayoutTargetType layoutTarget = plotArea.LayoutTargetType;

                // Output the information
                Console.WriteLine("Chart Plot Area Information:");
                Console.WriteLine($"Actual X: {actualX}");
                Console.WriteLine($"Actual Y: {actualY}");
                Console.WriteLine($"Actual Width: {actualWidth}");
                Console.WriteLine($"Actual Height: {actualHeight}");
                Console.WriteLine($"Relative X (fraction of chart width): {relativeX}");
                Console.WriteLine($"Relative Y (fraction of chart height): {relativeY}");
                Console.WriteLine($"Relative Width (fraction of chart width): {relativeWidth}");
                Console.WriteLine($"Relative Height (fraction of chart height): {relativeHeight}");
                Console.WriteLine($"Layout Target Type: {layoutTarget}");

                // Save the presentation
                presentation.Save("ChartPlotAreaInfo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}