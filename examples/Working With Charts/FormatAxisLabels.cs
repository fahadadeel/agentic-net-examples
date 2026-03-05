using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50, 50, 500, 400);

            // Set number format for the horizontal axis
            Aspose.Slides.Charts.IAxis horizontalAxis = chart.Axes.HorizontalAxis;
            horizontalAxis.NumberFormat = "0%";

            // Set number format for the vertical axis
            Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
            verticalAxis.NumberFormat = "#,##0";

            // Save the presentation
            presentation.Save("FormattedAxisLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}