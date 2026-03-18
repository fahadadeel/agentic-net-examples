using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
            var verticalAxis = chart.Axes.VerticalAxis;
            verticalAxis.DisplayUnit = DisplayUnitType.Millions;
            presentation.Save("DisplayUnitChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}