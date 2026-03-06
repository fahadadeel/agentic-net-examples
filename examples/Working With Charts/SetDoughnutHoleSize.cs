using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

namespace DoughnutHoleSizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a doughnut chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Doughnut,
                50, 50, 400, 400);

            // Access the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Access the parent series group and set the doughnut hole size (percentage of plot area)
            Aspose.Slides.Charts.IChartSeriesGroup seriesGroup = series.ParentSeriesGroup;
            seriesGroup.DoughnutHoleSize = (byte)50; // Set hole size to 50%

            // Save the presentation
            presentation.Save("DoughnutHoleSize_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}