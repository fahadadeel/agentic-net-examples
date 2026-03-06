using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ApplyDefaultMarkersToCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to save the presentation
            string outputPath = "DefaultMarkersChart_out.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a Line chart with markers
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.LineWithMarkers,
                0f, 0f, 500f, 500f);

            // Set default marker size and style for the first series
            chart.ChartData.Series[0].Marker.Size = 10;
            chart.ChartData.Series[0].Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}