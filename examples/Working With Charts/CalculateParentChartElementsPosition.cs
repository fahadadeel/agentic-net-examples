using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Calculate actual layout values
        chart.ValidateChartLayout();

        // Get actual position and size of the chart title
        Aspose.Slides.Charts.IChartTitle chartTitle = chart.ChartTitle;
        float titleX = chartTitle.ActualX;
        float titleY = chartTitle.ActualY;
        float titleWidth = chartTitle.ActualWidth;
        float titleHeight = chartTitle.ActualHeight;

        // Get actual position and size of the plot area
        Aspose.Slides.Charts.IChartPlotArea plotArea = chart.PlotArea;
        float plotX = plotArea.ActualX;
        float plotY = plotArea.ActualY;
        float plotWidth = plotArea.ActualWidth;
        float plotHeight = plotArea.ActualHeight;

        // Get actual position and size of the legend
        Aspose.Slides.Charts.ILegend legend = chart.Legend;
        float legendX = legend.ActualX;
        float legendY = legend.ActualY;
        float legendWidth = legend.ActualWidth;
        float legendHeight = legend.ActualHeight;

        // Output the values
        Console.WriteLine("Chart Title - X:{0}, Y:{1}, Width:{2}, Height:{3}", titleX, titleY, titleWidth, titleHeight);
        Console.WriteLine("Plot Area - X:{0}, Y:{1}, Width:{2}, Height:{3}", plotX, plotY, plotWidth, plotHeight);
        Console.WriteLine("Legend - X:{0}, Y:{1}, Width:{2}, Height:{3}", legendX, legendY, legendWidth, legendHeight);

        // Save the presentation
        presentation.Save("ParentChartElementsPosition.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}