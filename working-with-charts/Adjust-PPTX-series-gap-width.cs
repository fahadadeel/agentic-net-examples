using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            var slide = presentation.Slides[0];

            // Add a clustered column chart
            var chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0, 0, 500, 400);

            // Configure the gap width for the series group (percentage of bar width)
            chart.ChartData.Series[0].ParentSeriesGroup.GapWidth = 150; // 150%

            // Save the presentation
            presentation.Save("ChartGapWidth.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}