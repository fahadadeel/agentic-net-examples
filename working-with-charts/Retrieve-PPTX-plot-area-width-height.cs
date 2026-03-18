using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a chart to the slide
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

                    // Calculate actual layout values
                    chart.ValidateChartLayout();

                    // Retrieve plot area dimensions
                    IChartPlotArea plotArea = chart.PlotArea;
                    float actualWidth = plotArea.ActualWidth;
                    float actualHeight = plotArea.ActualHeight;

                    // Output the dimensions
                    Console.WriteLine("Plot Area Actual Width: " + actualWidth);
                    Console.WriteLine("Plot Area Actual Height: " + actualHeight);

                    // Save the presentation
                    pres.Save("ChartPlotArea.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}