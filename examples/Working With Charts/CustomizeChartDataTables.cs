using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 600f, 400f);

        // Enable the data table for the chart
        chart.HasDataTable = true;

        // Optional: customize other chart properties (e.g., show legend)
        chart.HasLegend = true;

        // Save the presentation to a PPTX file
        presentation.Save("CustomizeChartDataTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}