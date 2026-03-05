using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400).Chart;

        // Access the vertical (value) axis of the chart
        Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;

        // Disable automatic min and max values
        verticalAxis.IsAutomaticMinValue = false;
        verticalAxis.IsAutomaticMaxValue = false;

        // Set custom minimum and maximum values
        verticalAxis.MinValue = 0;
        verticalAxis.MaxValue = 200;

        // Disable automatic major unit and set a custom major unit
        verticalAxis.IsAutomaticMajorUnit = false;
        verticalAxis.MajorUnit = 50;

        // Save the presentation
        presentation.Save("AxisScalePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}