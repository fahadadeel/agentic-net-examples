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
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

        // Add a linear trend line to the first series
        Aspose.Slides.Charts.ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Linear);

        // Hide equation and R-squared value
        linearTrend.DisplayEquation = false;
        linearTrend.DisplayRSquaredValue = false;

        // Set trend line color to red
        linearTrend.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        linearTrend.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

        // Save the presentation
        presentation.Save("ChartWithTrendLine.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}