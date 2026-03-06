using System;

namespace AxisScaleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50, 50, 500, 400);

            // Disable automatic min/max values for the vertical axis
            chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
            chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;

            // Set custom scale for the vertical axis
            chart.Axes.VerticalAxis.MinValue = 0;
            chart.Axes.VerticalAxis.MaxValue = 100;
            chart.Axes.VerticalAxis.MajorUnit = 20;
            chart.Axes.VerticalAxis.MinorUnit = 5;

            // Save the presentation
            presentation.Save("AxisScale_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}