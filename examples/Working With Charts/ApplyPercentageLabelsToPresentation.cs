using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

namespace DisplayPercentageExample
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
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

                // Add categories (X-axis labels)
                chart.ChartData.Categories.Add("Category A");
                chart.ChartData.Categories.Add("Category B");
                chart.ChartData.Categories.Add("Category C");

                // Add data points for the first series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
                series.DataPoints.AddDataPointForPieSeries(30);
                series.DataPoints.AddDataPointForPieSeries(45);
                series.DataPoints.AddDataPointForPieSeries(25);

                // Enable percentage display for data labels
                series.Labels.DefaultDataLabelFormat.ShowPercentage = true;

                // Optionally hide other label elements
                series.Labels.DefaultDataLabelFormat.ShowValue = false;
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = false;

                // Save the presentation
                presentation.Save("DisplayPercentage.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}