using System;

namespace AddColumnChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

            // Switch rows and columns of the chart data
            chart.ChartData.SwitchRowColumn();

            // Save the presentation
            presentation.Save("ColumnChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}