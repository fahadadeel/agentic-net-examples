using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Add and format chart title
            chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
            chart.HasTitle = true;
            chart.ChartTitle.TextFormat.PortionFormat.FontHeight = 24f;
            chart.ChartTitle.TextFormat.PortionFormat.FontBold = NullableBool.True;

            // Set default chart text formatting
            chart.TextFormat.PortionFormat.FontHeight = 14f;
            chart.TextFormat.PortionFormat.FontBold = NullableBool.False;

            // Enable varied colors for the first series
            chart.ChartData.Series[0].ParentSeriesGroup.IsColorVaried = true;

            // Save the presentation
            presentation.Save("FormattedChart.pptx", SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}