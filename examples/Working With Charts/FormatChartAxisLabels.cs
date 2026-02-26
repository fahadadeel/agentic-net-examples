using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Set chart title (optional)
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sales Data");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

        // Get the value (vertical) axis of the chart
        Aspose.Slides.Charts.IAxis valueAxis = chart.Axes.VerticalAxis;

        // Set number format for the value axis labels
        valueAxis.NumberFormat = "#,##0";

        // Save the presentation to a file
        presentation.Save("FormattedAxisLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}