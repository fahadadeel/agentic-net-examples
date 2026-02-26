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

        // Access the first slide (already present)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a sample Doughnut chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Doughnut, 50f, 50f, 400f, 300f);

        // Set the doughnut hole size (example value)
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

        // List all supported chart types
        foreach (Aspose.Slides.Charts.ChartType chartType in Enum.GetValues(typeof(Aspose.Slides.Charts.ChartType)))
        {
            Console.WriteLine(chartType.ToString());
        }

        // Save the presentation before exiting
        presentation.Save("SupportedChartTypes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}