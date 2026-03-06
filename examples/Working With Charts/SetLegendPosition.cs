using System;

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

        // Set the legend position to TopRight
        Aspose.Slides.Charts.ILegend legend = chart.Legend;
        legend.Position = Aspose.Slides.Charts.LegendPositionType.TopRight;

        // Save the presentation
        presentation.Save("SetLegendPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}