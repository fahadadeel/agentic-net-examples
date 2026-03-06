using System;

namespace CustomizeErrorBarsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a Bubble chart with sample data
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                50f,   // X position
                50f,   // Y position
                400f,  // Width
                300f,  // Height
                true   // Initialize with sample data
            );

            // Get the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars
            Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
            errorBarsX.IsVisible = true;                                            // Show X error bars
            errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;    // Fixed length
            errorBarsX.Value = 0.5f;                                                // Fixed value
            errorBarsX.Type = Aspose.Slides.Charts.ErrorBarType.Plus;               // Positive direction only
            errorBarsX.HasEndCap = false;                                          // No end cap

            // Configure Y error bars
            Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
            errorBarsY.IsVisible = true;                                            // Show Y error bars
            errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage; // Percentage based
            errorBarsY.Value = 10;                                                  // 10%
            errorBarsY.Format.Line.Width = 2;                                       // Line width for Y error bars

            // Save the presentation
            presentation.Save("CustomizeErrorBars.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}