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

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Get the first data label of the first series
        Aspose.Slides.Charts.IDataLabel dataLabel = chart.ChartData.Series[0].Labels[0];

        // Adjust the label location (fraction of chart width/height)
        dataLabel.X = 0.2f; // 20% from the left edge of the chart
        dataLabel.Y = 0.8f; // 80% from the top edge of the chart

        // Save the presentation
        presentation.Save("AdjustLabelLocation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}