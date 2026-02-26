using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);
        // Set plot area fill to solid light gray
        chart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        chart.PlotArea.Format.Fill.SolidFillColor.Color = System.Drawing.Color.LightGray;
        // Set plot area border to solid black with single line style
        chart.PlotArea.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        chart.PlotArea.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
        chart.PlotArea.Format.Line.Style = Aspose.Slides.LineStyle.Single;
        chart.PlotArea.Format.Line.Width = 2f;
        // Save the presentation
        presentation.Save("SetPlotAreaStyle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}