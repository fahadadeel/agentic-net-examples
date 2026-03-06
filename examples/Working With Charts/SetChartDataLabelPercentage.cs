using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPercentageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a pie chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

                // Access the first series of the chart
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

                // Enable percentage display for data labels
                series.Labels.DefaultDataLabelFormat.ShowPercentage = true;

                // Set number format to show percentage sign
                series.Labels.DefaultDataLabelFormat.NumberFormat = "0%";

                // Save the presentation to a file
                presentation.Save("ChartPercentage_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}