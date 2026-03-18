using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ErrorBarsExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load an existing presentation
                var presentation = new Aspose.Slides.Presentation("input.pptx");

                // Access the first slide
                var slide = presentation.Slides[0];

                // Assume the first shape on the slide is a chart
                var chart = (Aspose.Slides.Charts.IChart)slide.Shapes[0];

                // Get the first series of the chart
                var series = chart.ChartData.Series[0];

                // Configure Y-direction error bars for the series
                var errorBars = series.ErrorBarsYFormat;
                errorBars.IsVisible = true;
                errorBars.Type = Aspose.Slides.Charts.ErrorBarType.Both;
                errorBars.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage;
                errorBars.Value = 10f; // 10 percent error bars

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}