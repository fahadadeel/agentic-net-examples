using System;

namespace DisplayPercentageLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a stacked column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.StackedColumn,
                0f, 0f, 500f, 400f);

            // Enable display of values and percentages as data labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

            // Save the presentation before exiting
            presentation.Save("DisplayPercentageLabels_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}