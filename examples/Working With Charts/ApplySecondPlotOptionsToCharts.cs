using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Add a Pie of Pie chart
        var pieOfPieChart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.PieOfPie, 50, 50, 400, 300);
        // Get the first series of the chart
        var pieSeries = pieOfPieChart.ChartData.Series[0];
        // Set the size of the second pie (percentage of the first pie)
        pieSeries.ParentSeriesGroup.SecondPieSize = 150; // 150%
        // Set the split type to Custom
        pieSeries.ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.Custom;
        // Example split position (used with certain split types)
        pieSeries.ParentSeriesGroup.PieSplitPosition = 30;

        // Add a Bar of Pie chart
        var barOfPieChart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.BarOfPie, 50, 400, 400, 300);
        var barSeries = barOfPieChart.ChartData.Series[0];
        // Set the size of the second bar (percentage of the first pie)
        barSeries.ParentSeriesGroup.SecondPieSize = 120; // 120%
        // Set the split type to ByValue
        barSeries.ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByValue;
        // Example split position for ByValue split type
        barSeries.ParentSeriesGroup.PieSplitPosition = 20;

        // Save the presentation
        presentation.Save("SecondPlotOptions.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}