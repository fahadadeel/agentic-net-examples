using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace DoughnutHoleSizeExample
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

                // Add a doughnut chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50f, 50f, 400f, 400f);

                // Set the doughnut hole size (center gap) to 50%
                // Access the first series and its parent series group
                IChartSeries series = chart.ChartData.Series[0];
                series.ParentSeriesGroup.DoughnutHoleSize = 50; // value between 10 and 90

                // Save the presentation
                presentation.Save("DoughnutHoleSize.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}