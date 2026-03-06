using System;

namespace CustomizeDoughnutChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a doughnut chart to the slide (x, y, width, height)
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Doughnut,
                50f, 50f, 400f, 400f);

            // Set the doughnut hole size (percentage of the plot area, 0-90)
            chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

            // Save the presentation
            pres.Save("DoughnutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}