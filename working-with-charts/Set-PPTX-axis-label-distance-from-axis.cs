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

            // Add a clustered column chart to the slide
            var chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50,   // X position
                50,   // Y position
                500,  // Width
                400   // Height
            );

            // Configure the distance between axis labels and the axis (10% offset)
            chart.Axes.HorizontalAxis.LabelOffset = (ushort)100;

            // Save the presentation
            presentation.Save("AxisLabelOffset.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}