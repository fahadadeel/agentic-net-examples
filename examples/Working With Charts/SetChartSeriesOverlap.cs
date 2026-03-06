using System;

class Program
{
    static void Main()
    {
        // Output file path
        string outputFile = "SetChartSeriesOverlap.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Get the series collection
        Aspose.Slides.Charts.IChartSeriesCollection series = chart.ChartData.Series;

        // If the first series has default overlap (0), set a new overlap value
        if (series[0].Overlap == 0)
        {
            series[0].ParentSeriesGroup.Overlap = (sbyte)55; // Set overlap to 55%
        }

        // Save the presentation
        presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}