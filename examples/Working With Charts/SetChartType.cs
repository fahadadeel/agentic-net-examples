using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation (lifecycle rule)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a chart with sample data (using the AddChart method)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, // initial type
            0f,   // X position
            0f,   // Y position
            500f, // width
            400f  // height
        );

        // Change the chart type to Pie
        chart.Type = Aspose.Slides.Charts.ChartType.Pie;

        // Save the presentation before exiting (lifecycle rule)
        presentation.Save("SetChartType_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}