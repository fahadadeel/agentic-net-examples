using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Get the first shape as a chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Iterate through each series and retrieve its automatic fill color
            Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;
            foreach (Aspose.Slides.Charts.IChartSeries series in seriesCollection)
            {
                Color autoColor = series.GetAutomaticSeriesColor();
                Console.WriteLine("Series automatic color: " + autoColor);
            }

            // Save the presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}