using System;

class Program
{
    static void Main()
    {
        // Create a new presentation.
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide.
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Export the chart as an image (PNG).
        Aspose.Slides.IImage chartImage = chart.GetImage();
        chartImage.Save("chart.png", Aspose.Slides.ImageFormat.Png);

        // Save the presentation in PPTX format.
        presentation.Save("ExportFormatsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}