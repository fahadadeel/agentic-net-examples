using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HideChartElements
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400) as IChart;

                // Hide various data label elements for the first series
                IChartSeries series = chart.ChartData.Series[0];
                series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;
                series.Labels.DefaultDataLabelFormat.ShowValue = false;
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = false;
                series.Labels.DefaultDataLabelFormat.ShowSeriesName = false;
                series.Labels.DefaultDataLabelFormat.ShowPercentage = false;
                series.Labels.DefaultDataLabelFormat.ShowBubbleSize = false;

                // Save the presentation
                pres.Save("HideChartElements_out.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}