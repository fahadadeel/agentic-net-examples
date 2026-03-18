using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Configure the first series to use inverted fill colors
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series.InvertedSolidFillColor.Color = Color.Red;

            // Save the presentation
            presentation.Save("InvertedFillSeries.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}