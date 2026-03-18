using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);
            chart.HasLegend = true;
            chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;
            chart.Legend.Overlay = false;
            chart.Legend.Height = 0.2f;
            chart.Legend.Width = 0.3f;
            chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;
            presentation.Save("ChartLegendDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}