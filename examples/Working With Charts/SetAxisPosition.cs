using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (default slide)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400).Chart;

        // Set the position of the category (horizontal) axis to Bottom
        Aspose.Slides.Charts.IAxis categoryAxis = chart.Axes.HorizontalAxis;
        categoryAxis.Position = Aspose.Slides.Charts.AxisPositionType.Bottom;

        // Set the position of the value (vertical) axis to Left
        Aspose.Slides.Charts.IAxis valueAxis = chart.Axes.VerticalAxis;
        valueAxis.Position = Aspose.Slides.Charts.AxisPositionType.Left;

        // Save the presentation
        presentation.Save("AxisPositionExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}