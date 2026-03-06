using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace CustomizeTrendLineStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart (float parameters)
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Add an exponential trendline and hide its equation and R‑squared value
            Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Exponential);
            trendline.DisplayEquation = false;
            trendline.DisplayRSquaredValue = false;

            // Add a linear trendline and set its line color to red
            trendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Linear);
            trendline.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            trendline.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

            // Add a logarithmic trendline and set custom text
            trendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Logarithmic);
            trendline.AddTextFrameForOverriding("Logarithmic Trend");

            // Add a moving average trendline, set period and name
            trendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.MovingAverage);
            trendline.Period = 3; // byte value
            trendline.TrendlineName = "MA3";

            // Add a polynomial trendline, set order and forward extension
            trendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Polynomial);
            trendline.Order = 2; // byte value
            trendline.Forward = 1.0; // double value

            // Add a power trendline and set backward extension
            trendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Power);
            trendline.Backward = 2.0; // double value

            // Save the presentation
            presentation.Save("CustomizeTrendLineStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}