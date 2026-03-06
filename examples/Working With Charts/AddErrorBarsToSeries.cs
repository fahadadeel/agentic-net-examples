using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddErrorBarsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Ensure the chart type supports Y error bars
            if (ChartTypeCharacterizer.IsErrorBarsYAllowed(chart.Type))
            {
                // Get the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];

                // Access the Y-direction error bars format
                IErrorBarsFormat errorBars = series.ErrorBarsYFormat;

                // Make error bars visible
                errorBars.IsVisible = true;

                // Set the error bar type (both positive and negative)
                errorBars.Type = ErrorBarType.Both;

                // Use a fixed value for the length of the error bars
                errorBars.ValueType = ErrorBarValueType.Fixed;
                errorBars.Value = 5f; // Length of error bars
            }

            // Save the presentation
            pres.Save("ErrorBarsChart.pptx", SaveFormat.Pptx);
        }
    }
}