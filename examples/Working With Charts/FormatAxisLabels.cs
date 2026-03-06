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

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Show display unit label in millions (using showing-display-unit-label rule)
        chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

        // Set number format for vertical axis labels
        chart.Axes.VerticalAxis.NumberFormat = "#,##0";

        // Set label offset for horizontal axis (using set-category-axis-label-distance rule)
        chart.Axes.HorizontalAxis.LabelOffset = (ushort)20;

        // Save the presentation before exiting
        presentation.Save("FormattedAxisLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}