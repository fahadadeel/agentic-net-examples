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
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);
            IAxis horizontalAxis = chart.Axes.HorizontalAxis;
            horizontalAxis.LabelOffset = (ushort)200;
            pres.Save("AxisLabelOffset.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}