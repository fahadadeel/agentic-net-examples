using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Iterate through each series and retrieve its automatic fill color
        for (int i = 0; i < chart.ChartData.Series.Count; i++)
        {
            Color automaticColor = chart.ChartData.Series[i].GetAutomaticSeriesColor();
            Console.WriteLine("Series {0} automatic color: {1}", i, automaticColor);
        }

        // Save the presentation before exiting
        presentation.Save("AutomaticSeriesColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}