using System;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 100f, 100f, 500f, 350f);

        // Calculate actual layout values
        chart.ValidateChartLayout();

        // Retrieve plot area dimensions
        double plotX = chart.PlotArea.ActualX;
        double plotY = chart.PlotArea.ActualY;
        double plotWidth = chart.PlotArea.ActualWidth;
        double plotHeight = chart.PlotArea.ActualHeight;

        // Example usage: display the values
        Console.WriteLine("Plot Area X: " + plotX);
        Console.WriteLine("Plot Area Y: " + plotY);
        Console.WriteLine("Plot Area Width: " + plotWidth);
        Console.WriteLine("Plot Area Height: " + plotHeight);

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}