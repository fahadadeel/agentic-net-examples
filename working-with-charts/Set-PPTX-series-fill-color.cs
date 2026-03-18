using System;
using System.Drawing;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Retrieve the first chart on the slide
                IChart chart = slide.Shapes[0] as IChart;
                if (chart != null)
                {
                    // Get the first series of the chart
                    IChartSeries series = chart.ChartData.Series[0];

                    // Set the fill type to solid and apply a red color
                    series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                    series.Format.Fill.SolidFillColor.Color = Color.Red;
                }

                // Save the modified presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}