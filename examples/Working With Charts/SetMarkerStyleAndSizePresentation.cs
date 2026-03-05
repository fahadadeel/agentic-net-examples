using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a line chart with markers
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.LineWithMarkers, 0f, 0f, 400f, 400f);

        // Set marker size and style for the first series
        chart.ChartData.Series[0].Marker.Size = 10;
        chart.ChartData.Series[0].Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;

        // Save the presentation
        pres.Save("SetMarkerStyleAndSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}