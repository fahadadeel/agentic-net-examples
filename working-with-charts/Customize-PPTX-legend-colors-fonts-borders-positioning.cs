using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace CustomizeLegend
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Ensure the chart has a legend
                chart.HasLegend = true;

                // Set custom legend position and size (fraction of chart dimensions)
                chart.Legend.X = 0.7f;      // 70% from the left
                chart.Legend.Y = 0.1f;      // 10% from the top
                chart.Legend.Width = 0.2f;  // 20% of chart width
                chart.Legend.Height = 0.2f; // 20% of chart height

                // Optionally set the legend position enum (overridden by X/Y/Width/Height)
                chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;

                // Set legend font size
                chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

                // Set legend background fill color
                chart.Legend.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                chart.Legend.Format.Fill.SolidFillColor.Color = Color.LightGray;

                // Set legend border (line) color and width
                chart.Legend.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                chart.Legend.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
                chart.Legend.Format.Line.Width = 2f;

                // Save the presentation
                presentation.Save("CustomizedLegend.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}