using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SaveChartAsImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the output files
            string chartImagePath = "chart.png";
            string presentationOutputPath = "output.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f,   // X position
                50f,   // Y position
                400f,  // Width
                300f   // Height
            );

            // Generate an image of the chart
            Aspose.Slides.IImage chartImage = chart.GetImage();

            // Save the chart image as PNG
            chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);

            // Save the presentation (required before exiting)
            presentation.Save(presentationOutputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}