using System;
using System.Drawing;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            Aspose.Slides.ISlide slide = pres.Slides[0];
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.PieOfPie, 50, 50, 500, 400);
            var series = chart.ChartData.Series[0];
            series.ParentSeriesGroup.SecondPieSize = 150;
            series.ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
            pres.Save("SecondPieSizeChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}