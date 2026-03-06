using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f,   // X position
            50f,   // Y position
            500f,  // Width
            400f   // Height
        );

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Set the series fill type to solid (required for inverted solid fill color)
        series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;

        // Set the inverted solid fill color for the series
        series.InvertedSolidFillColor.Color = Color.Blue;

        // Save the presentation to a PPTX file
        presentation.Save("SetInvertFillColorChartSeries.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}