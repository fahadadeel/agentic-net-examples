using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the first chart on the first slide (adjust indices as needed)
        Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)presentation.Slides[0].Shapes[0];

        // Validate layout to ensure actual dimensions are calculated
        chart.ValidateChartLayout();

        // Access the plot area of the chart
        Aspose.Slides.Charts.IChartPlotArea plotArea = chart.PlotArea;

        // Retrieve actual width and height of the plot area
        float actualWidth = plotArea.ActualWidth;
        float actualHeight = plotArea.ActualHeight;

        // Output the dimensions
        Console.WriteLine("Plot Area Actual Width: " + actualWidth);
        Console.WriteLine("Plot Area Actual Height: " + actualHeight);

        // Save the presentation (required before exit)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}