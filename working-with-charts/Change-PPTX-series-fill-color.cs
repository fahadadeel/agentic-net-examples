using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];
                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);
                // Access the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];
                // Set the series fill type to solid and color to red
                series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series.Format.Fill.SolidFillColor.Color = Color.Red;
                // Save the modified presentation
                pres.Save("ChangeSeriesFillColor_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}