using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetAxisPositionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Get the horizontal (category) axis
            IAxis horizontalAxis = chart.Axes.HorizontalAxis;
            // Set the position of the horizontal axis to the bottom
            horizontalAxis.Position = AxisPositionType.Bottom;

            // Get the vertical (value) axis
            IAxis verticalAxis = chart.Axes.VerticalAxis;
            // Set the position of the vertical axis to the left
            verticalAxis.Position = AxisPositionType.Left;

            // Save the presentation
            presentation.Save("SetAxisPosition.pptx", SaveFormat.Pptx);
        }
    }
}