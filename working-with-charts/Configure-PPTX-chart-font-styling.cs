using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFontExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Presentation pres = new Presentation();
                ISlide slide = pres.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
                // Set chart title font attributes
                chart.ChartTitle.TextFormat.PortionFormat.FontHeight = 24f;
                chart.ChartTitle.TextFormat.PortionFormat.FontBold = NullableBool.True;
                // Enable legend and set its font attributes
                chart.HasLegend = true;
                chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;
                chart.Legend.TextFormat.PortionFormat.FontItalic = NullableBool.True;
                // Save the presentation
                pres.Save("ChartFontExample.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}