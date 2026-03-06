using System;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart on the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

            // Add Exponential trendline to the first series
            Aspose.Slides.Charts.ITrendline expTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Exponential);
            expTrendline.DisplayEquation = false;
            expTrendline.DisplayRSquaredValue = false;

            // Add Linear trendline and set its line color to red
            Aspose.Slides.Charts.ITrendline linearTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Linear);
            linearTrendline.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

            // Add Logarithmic trendline with a custom name
            Aspose.Slides.Charts.ITrendline logTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Logarithmic);
            logTrendline.AddTextFrameForOverriding("Log Trendline");

            // Add Moving Average trendline with period 3 and a custom name
            Aspose.Slides.Charts.ITrendline maTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.MovingAverage);
            maTrendline.Period = 3;
            maTrendline.TrendlineName = "3-Period MA";

            // Add Polynomial trendline with order 2 and forward 1
            Aspose.Slides.Charts.ITrendline polyTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Polynomial);
            polyTrendline.Order = 2;
            polyTrendline.Forward = 1;

            // Add Power trendline with backward 2
            Aspose.Slides.Charts.ITrendline powerTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Power);
            powerTrendline.Backward = 2;

            // Save the presentation
            presentation.Save("ChartTrendLines_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}