using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace GetChartImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Get the chart image
            Aspose.Slides.IImage chartImage = chart.GetImage();

            // Save the chart image as PNG
            string chartImagePath = "chart.png";
            chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);

            // Save the presentation
            string presentationOutputPath = "output.pptx";
            presentation.Save(presentationOutputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}