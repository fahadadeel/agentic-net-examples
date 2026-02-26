using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesBubbleChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a bubble chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Set bubble size representation to Width
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

            // Set bubble size scale (e.g., 150 percent of default size)
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

            // Save the presentation
            presentation.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}